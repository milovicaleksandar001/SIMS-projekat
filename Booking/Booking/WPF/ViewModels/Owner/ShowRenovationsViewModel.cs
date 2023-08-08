using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class ShowRenovationsViewModel : IObserver
    {
        public ObservableCollection<AccommodationRenovation> Renovations { get; set; }
        public IAccommodationRenovationService AccommodationRenovationService { get; set; }
        public IAccommodationReservationService AccommodationReservationService { get; set; }
        public AccommodationRenovation SelectedRenovation { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand Delete { get; set; }
        public RelayCommand ShowDescription { get; set; }
        public RelayCommand Wizard { get; set; }
        private readonly Window _window;
        public ShowRenovationsViewModel(Window window)
        {
            _window = window;
            AccommodationRenovationService = InjectorService.CreateInstance<IAccommodationRenovationService>();
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();

            AccommodationRenovationService.Subscribe(this);
            Renovations = new ObservableCollection<AccommodationRenovation>(AccommodationRenovationService.GetSeeableRenovations());
            SetCommands();
        }
        public void SetCommands()
        {
            Close = new RelayCommand(CloseWindow);
            Delete = new RelayCommand(DeleteRenovation);
            ShowDescription = new RelayCommand(ShowDescriptionWindow);
            Wizard = new RelayCommand(OpenWizard);

        }
        public void Update()
        {
            Renovations.Clear();
            foreach (AccommodationRenovation r in AccommodationRenovationService.GetSeeableRenovations())
            {
                Renovations.Add(r);
            }
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(12);
            wizard.Show();
        }
        private void CloseWindow(object param)
        {
            _window.Close();
        }
        private void ShowDescriptionWindow(object param)
        {
            ShowDescriptionForRenovation showDescriptionText = new ShowDescriptionForRenovation(SelectedRenovation.Id);
            showDescriptionText.Show();
        }
        private void DeleteRenovation(object param)
        {
            if (SelectedRenovation == null)
            {
                System.Windows.MessageBox.Show("Select a renovation to delete", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);               
                return;
            }
            else if (SelectedRenovation.StartDay.AddDays(5) > DateTime.Now) 
            {
                System.Windows.MessageBox.Show("You can only delete renovation which will happen in more than 5 days", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else
            {
                AccommodationReservation reservation = new AccommodationReservation();
                reservation = AccommodationReservationService.GetByRenovation(SelectedRenovation);
                AccommodationRenovationService.Delete(SelectedRenovation);
                AccommodationReservationService.Delete(reservation);
            }
        }
    }
}
