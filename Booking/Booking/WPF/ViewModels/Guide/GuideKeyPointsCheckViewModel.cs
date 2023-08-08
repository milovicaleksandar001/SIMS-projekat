using Booking.Model;
using Booking.Observer;
using Booking.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Resources;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using Booking.View.Guide;
using Booking.View;
using System.ComponentModel;
using System.Windows.Navigation;
using Booking.Commands;
using Booking.WPF.Views.Guide;


namespace Booking.WPF.ViewModels.Guide
{
    public class GuideKeyPointsCheckViewModel : IObserver, INotifyPropertyChanged
    {

        public ObservableCollection<TourKeyPoint> KeyPoints { get; set; }
        public ObservableCollection<User> Guests { get; set; }

        public ITourService TourService { get; set; }
        public IUserService UserService { get; set; }
        public ITourGuestsService TourGuestsService { get; set; }
        public IVoucherService VoucherService { get; set; }

        public TourKeyPoint SelectedTourKeyPoint { get; set; }
        public Tour SelectedTour { get; set; }
        public User SelectedGuest { get; set; }

        public TourGuests tourGuests = new TourGuests();

        public RelayCommand AchieveKeypoint { get;set; }
        public RelayCommand AddGuest { get; set; }
        
        
        private readonly Window _window;

        public event PropertyChangedEventHandler PropertyChanged;

        public GuideKeyPointsCheckViewModel(int idTour, Window window)
        {
            _window = window;

            TourService = InjectorService.CreateInstance<ITourService>();
            TourService.Subscribe(this);

            UserService = InjectorService.CreateInstance<IUserService>();
            UserService.Subscribe(this);

            TourGuestsService = InjectorService.CreateInstance<ITourGuestsService>();
            TourGuestsService.Subscribe(this);

            VoucherService = InjectorService.CreateInstance<IVoucherService>();
            VoucherService.Subscribe(this);

            SelectedTour = TourService.GetById(idTour);

            Guests = new ObservableCollection<User>(UserService.GetReservedGuests(SelectedTour.Id));
            KeyPoints = new ObservableCollection<TourKeyPoint>(TourService.GetSelectedTourKeyPoints(SelectedTour.Id));

            KeyPoints[0].Achieved = true;
            TourService.UpdateKeyPoint(KeyPoints[0]);
            SetCommands();
        }

        private void SetCommands() 
        {
            AchieveKeypoint = new RelayCommand(ButtonAchieveKeypoint);
            AddGuest = new RelayCommand(ButtonAddGuest);
        }

        private void CloseWindow()
        {
            _window.Close();
        }
        private void ButtonAchieveKeypoint(object param)
        {
            if (SelectedTourKeyPoint != null)
            {
                SelectedTourKeyPoint.Achieved = true;
                TourService.UpdateKeyPoint(SelectedTourKeyPoint);
                System.Windows.MessageBox.Show(SelectedTourKeyPoint.Location.State.ToString() + " " + SelectedTourKeyPoint.Location.City.ToString() + " is achieved!", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                TourService.NotifyObservers();
                EndTour();
            }
            else
            {
                System.Windows.MessageBox.Show("You must first mark the keypoint that has been achieved!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void EndTour()
        {
            if (KeyPoints[KeyPoints.Count() - 1].Achieved == true)
            {
                SelectedTour.IsStarted = false;
                SelectedTour.IsEnded = true;
                TourService.UpdateTour(SelectedTour);
                System.Windows.MessageBox.Show("Tour ended, you achieved last keypoint!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                TourService.NotifyObservers();

                CloseWindow();
            }
        }

        private void ButtonAddGuest(object param)
        {
            List<Voucher> pomVouchers = new List<Voucher>();

            tourGuests.Voucher = false;
            if (SelectedGuest != null && SelectedTourKeyPoint != null)
            {
                if (TourService.checkTourGuests(SelectedTour.Id, SelectedGuest.Id) == true)
                {

                    tourGuests.Tour.Id = SelectedTour.Id;
                    tourGuests.User.Id = SelectedGuest.Id;
                    tourGuests.TourKeyPoint.Id = SelectedTourKeyPoint.Id;

                    CheckVouchers(pomVouchers);

                    TourGuestsService.Create(tourGuests);

                    foreach (Voucher v in pomVouchers)
                    {
                        VoucherService.Update(v);
                    }
                    System.Windows.MessageBox.Show("Guest '" + SelectedGuest.Username.ToString() + "' is added to keypoint '" + SelectedTourKeyPoint.Location.State.ToString() + ", " + SelectedTourKeyPoint.Location.City.ToString() + "'", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                else
                {
                    System.Windows.MessageBox.Show("Guest is already added to this tour", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("You must first mark the guest and checkpoint who you want to add and where!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

        }

        private void CheckVouchers(List<Voucher> pomVouchers)
        {
            foreach (Voucher v in VoucherService.GetUserVouchers(tourGuests.User.Id))
            {
                Voucher pomVoucher = VoucherService.GetById(v.Id);

                if (pomVoucher.IsActive == true)
                {
                    MessageBoxResult result = ConfirmVoucherUse();
                    if (result == MessageBoxResult.Yes)
                    {
                        tourGuests.Voucher = true;
                        pomVoucher.IsActive = false;
                        System.Windows.MessageBox.Show("Guest " + SelectedGuest.Username.ToString() + " used voucher", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                        pomVouchers.Add(pomVoucher);
                    }
                }
            }
        }

        private MessageBoxResult ConfirmVoucherUse()
        {
            string sMessageBoxText = $"Are guest want to use voucher?";
            string sCaption = "Voucher";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            return result;
        }

        public void Update()
        {
            KeyPoints.Clear();
            foreach (TourKeyPoint keyPoint in TourService.GetSelectedTourKeyPoints(SelectedTour.Id))
            {
                KeyPoints.Add(keyPoint);
            }

            Guests.Clear();
            foreach (User user in UserService.GetReservedGuests(SelectedTour.Id))
            {
                Guests.Add(user);
            }
        }


    }
}
