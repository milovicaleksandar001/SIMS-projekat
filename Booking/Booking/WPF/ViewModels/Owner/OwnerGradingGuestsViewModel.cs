using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using Booking.View;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class OwnerGradingGuestsViewModel : IObserver
    {
        public IAccommodationReservationService AccommodationReservationService { get; set; }
        public ObservableCollection<AccommodationReservation> reservations { get; set; }
        public AccommodationReservation SelectedReservation { get; set; }
        public RelayCommand Grade { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand Wizard { get; set; }

        private readonly Window _window;

        public OwnerGradingGuestsViewModel(Window window)
        {
            _window = window;
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            AccommodationReservationService.Subscribe(this);

            reservations = new ObservableCollection<AccommodationReservation>(AccommodationReservationService.GetAllUngradedReservations());
            SetCommands();
        }
        public void SetCommands()
        {
            Grade = new RelayCommand(Button_Click_Grade);
            Close = new RelayCommand(Button_Click_Close);
            Wizard = new RelayCommand(OpenWizard);

        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(6);
            wizard.Show();
        }
        private void Button_Click_Close(object param)
        {
            _window.Close();
        }

        private void Button_Click_Grade(object param)
        {
            if (SelectedReservation == null)
            {
                System.Windows.MessageBox.Show("Choose a reservation to grade", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else 
            { 
            GradingWindow gradingWindow = new GradingWindow(SelectedReservation.Id);
            gradingWindow.Show();
            }
        }
        public void Update()
        {
            reservations.Clear();

            foreach (AccommodationReservation r in AccommodationReservationService.GetAllUngradedReservations())
            {
                reservations.Add(r);
            }
        }

        public void RefreshWindow()
        {
            List<AccommodationReservation> accomodationReservations = AccommodationReservationService.GetAllUngradedReservations();
            reservations.Clear();
            foreach (AccommodationReservation accommodationReservation in accomodationReservations)
            {
                reservations.Add(accommodationReservation);
            }
        }
    }
}
