using Booking.Model;
using Booking.Observer;
using System.Collections.ObjectModel;
using System.Windows;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using Booking.View.Guide;
using Booking.View;
using System.ComponentModel;
using Booking.Commands;
using Booking.WPF.Views.Guide;
using Booking.Service;
using SkiaSharp;
using System;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideHomePageViewModel : IObserver, INotifyPropertyChanged
    {
        public ObservableCollection<Tour> Tours { get; set; }
        public ITourService _tourService { get; set; }
        public IUserService _userService { get; set; }

        public Tour SelectedTour { get; set; }
        public User user { get; set; }

        public static string _username;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private bool _isDemoMode;
        public bool IsDemoMode
        {
            get { return _isDemoMode; }
            set
            {
                if (_isDemoMode != value)
                {
                    _isDemoMode = value;
                    OnPropertyChanged(nameof(IsDemoMode));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand OpenCreateTour { get; set; }
        public RelayCommand OpenStatisticsAboutTour { get; set; }
        public RelayCommand OpenFollowTourLive { get; set; }
        public RelayCommand OpenViewReviews { get; set; }
        public RelayCommand OpenCreateTourBasedOnRequests { get; set; }
        public RelayCommand LogOut { get; set; }
        public RelayCommand CancelTour { get; set; }
        public RelayCommand ShowDescriptionText { get; set; }
        public RelayCommand OpenAcceptTourRequest { get; set; }
        public RelayCommand OpenTourRequestStatistic { get; set; }
        public RelayCommand OpenSuperGuide { get; set; }
        public RelayCommand OpenAcceptPartTour { get; set; }
        public RelayCommand Dismissal { get; set; }
        public RelayCommand DemoMode { get; set; }

        public static bool isDemoCreatedTour;

        public static bool pom;


        private readonly Window _window;

        public GuideHomePageViewModel(Window window)
        {
            _window = window;
            _tourService = InjectorService.CreateInstance<ITourService>();
            _userService = InjectorService.CreateInstance<IUserService>();

            _tourService.Subscribe(this);

            Tours = new ObservableCollection<Tour>(_tourService.GetGuideTours());

            SetCommands();
            
        }
        public void DemoModeCancelTour()
        {
            SelectedTour = Tours[Tours.Count - 1];
            ButtonCancelTour(this);
        }

            private void CloseWindow()
        { 
            _window.Close();
        }
        public void SetCommands()
        {
            OpenCreateTour = new RelayCommand(ButtonCreateTour);
            OpenStatisticsAboutTour = new RelayCommand(ButtonStatisticAboutTour);
            OpenFollowTourLive = new RelayCommand(ButtonFollowTourLive);
            OpenViewReviews = new RelayCommand(ButtonViewReviews);
            OpenCreateTourBasedOnRequests = new RelayCommand(ButtonOpenCreateTourBasedOnRequests);
            LogOut = new RelayCommand(ButtonLogOut);
            CancelTour = new RelayCommand(ButtonCancelTour);
            ShowDescriptionText = new RelayCommand(ButtonShowDescriptionText);
            OpenAcceptTourRequest = new RelayCommand(ButtonOpenAcceptTourRequest);
            OpenTourRequestStatistic = new RelayCommand(ButtonOpenTourRequestStatistic);
            OpenSuperGuide = new RelayCommand(ButtonOpenSuperGuide);
            OpenAcceptPartTour = new RelayCommand(ButtonOpenAcceptPartTour);
            Dismissal = new RelayCommand(ButtonDismissal);
            DemoMode = new RelayCommand(ButtonDemoMode);
        }

        private void ButtonCreateTour(object param)
        {
              GuideCreateTour guideCreateTour = new GuideCreateTour();
              guideCreateTour.ShowDialog();
        }

        private void ButtonStatisticAboutTour(object param)
        {
            GuideStatisticAboutTours statistics = new GuideStatisticAboutTours();
            statistics.ShowDialog();
        }

        private void ButtonFollowTourLive(object param)
        {
            GuideFollowTourLive guideFollowTourLive = new GuideFollowTourLive();
            GuideFollowTourLiveViewModel guideFollowTourLiveViewModel = new GuideFollowTourLiveViewModel(guideFollowTourLive);
            if (guideFollowTourLiveViewModel.Tours.Count > 0)
                guideFollowTourLive.ShowDialog();
            else
                System.Windows.MessageBox.Show("Today you don't have tours!", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }

        private void ButtonViewReviews(object param)
        {
            GuideViewReviews reviews = new GuideViewReviews();
            reviews.ShowDialog();
        }
        private void ButtonLogOut(object param)
        {
            MessageBoxResult result = ConfirmLogOut();

            if (result == MessageBoxResult.Yes)
            {
                SignInForm signInForm = new SignInForm();
                signInForm.Show();
                CloseWindow();
            }
        }

        private MessageBoxResult ConfirmLogOut()
        {
            string sMessageBoxText = $"Are you sure to log out?";
            string sCaption = "Confirmation of log out";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            return result;
        }
        private void ButtonCancelTour(object param)
        {
            if (SelectedTour != null)
            {
                MessageBoxResult result = ConfirmTourCancel();

                if (result == MessageBoxResult.Yes)
                {
                    _tourService.removeTour(SelectedTour.Id);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("You need to select tour if you want to cancel it!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void ButtonOpenCreateTourBasedOnRequests(object param)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.ShowDialog();
        }
        private MessageBoxResult ConfirmTourCancel()
        {
            string sMessageBoxText = $"Are you sure to cancel tour\n{SelectedTour.Name}";
            string sCaption = "Confirmation of cancellation";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            return result;
        }

        private void ButtonShowDescriptionText(object param)
        {
            ShowDescription showDescriptionText = new ShowDescription(SelectedTour.Id);
            showDescriptionText.Show();
        }
        private void ButtonOpenAcceptTourRequest(object param)
        {
            GuideAcceptingTourRequest guideAcceptingTourRequest = new GuideAcceptingTourRequest();
            guideAcceptingTourRequest.ShowDialog();
        }
        private void ButtonOpenTourRequestStatistic(object param)
        {
            GuideRequestsStatistic guideRequestsStatistic = new GuideRequestsStatistic();
            guideRequestsStatistic.ShowDialog();
        }

        private void ButtonOpenSuperGuide(object param)
        {
            GuideSuperGuide guideSuperGuide = new GuideSuperGuide();
            guideSuperGuide.ShowDialog();
        }

        private void ButtonOpenAcceptPartTour(object param)
        {
            GuideAcceptingPartOfTour guideAcceptingPartOfTour = new GuideAcceptingPartOfTour();
            guideAcceptingPartOfTour.ShowDialog();
        }

        private void ButtonDismissal(object param)
        {
            MessageBoxResult result = ConfirmDismissal();

            if (result == MessageBoxResult.Yes)
            {
                _userService.removeUser(TourService.SignedGuideId);
                _tourService.RemoveGuideTours(TourService.SignedGuideId);

                SignInForm signInForm = new SignInForm();
                signInForm.Show();
                CloseWindow();
            }
        }

        private MessageBoxResult ConfirmDismissal()
        {
            string sMessageBoxText = $"\"Are you sure to give dismissal?\"";
            string sCaption = "Confirmation of dismissal";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            return result;
        }

        public void RunDemo()
        {
            GuideCreateTourViewModel.demoPom = true;
            GuideCreateTour guideCreateTour = new GuideCreateTour();
            guideCreateTour.ShowDialog();
        }
        private async void ButtonDemoMode(object param)
        {
            MessageBoxResult result = ConfirmDemoMode();

            if (result == MessageBoxResult.Yes)
            {
                IsDemoMode = true;
                System.Windows.MessageBox.Show("Demo mode enabled", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                RunDemo();
                await Task.Delay(750);
                DemoModeCancelTour();
                IsDemoMode = false;
                GuideCreateTourViewModel.demoPom = false;
            }
        }


        private MessageBoxResult ConfirmDemoMode()
        {
            string sMessageBoxText = $"Are you sure to start demo mode?";
            string sCaption = "Confirmation of Demo Mode";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            return result;
        }
        public void Update()
        {
            Tours.Clear();

            foreach (Tour t in _tourService.GetGuideTours())
            {
                Tours.Add(t);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
