using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using Booking.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using Booking.Commands;
using Notifications.Wpf;

namespace Booking.WPF.ViewModels.Guest1
{
    public class ReschaduleAccommodationReservationViewModel
    {
        public String AccommodationLabel { get; set; } = String.Empty;
        public String ReservedDaysLabel { get; set; } = String.Empty;
        public AccommodationReservation AccommodationReservation { get; set; }

        public IAccommodationReservationRequestService AccommodationReservationRequestsService { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime _arrivalDay;
        public DateTime NewArrivalDay
        {
            get => _arrivalDay;
            set
            {
                if (_arrivalDay != value)
                {
                    _arrivalDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime _departureDay;
        public DateTime NewDepartureDay
        {
            get => _departureDay;
            set
            {
                if (_departureDay != value)
                {
                    _departureDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand Button_Click_SendRequest {get; set;}

        public NavigationService NavigationService { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReschaduleAccommodationReservationViewModel(AccommodationReservation SelectedReservation, NavigationService navigationService)
        {
            AccommodationReservation = SelectedReservation;

            AccommodationReservationRequestsService = InjectorService.CreateInstance<IAccommodationReservationRequestService>();

            AccommodationLabel = SetAccommodationLabel(SelectedReservation);
            ReservedDaysLabel = SetReservedDaysLabel(SelectedReservation);
            NewDepartureDay = DateTime.Now;
            NewArrivalDay = DateTime.Now;

            NavigationService = navigationService;
            Button_Click_SendRequest = new RelayCommand(ButtonSendRequest);
        }

        private String SetAccommodationLabel(AccommodationReservation accommodationReservation)
        {
            return accommodationReservation.Accommodation.Name + "-" + accommodationReservation.Accommodation.Location.State + "-" + accommodationReservation.Accommodation.Location.City + "-" + accommodationReservation.Accommodation.Type;

        }
        private String SetReservedDaysLabel(AccommodationReservation accommodationReservation)
        {
            return accommodationReservation.ArrivalDay.ToShortDateString() + "-" + accommodationReservation.DepartureDay.ToShortDateString();
        }

        private void ButtonSendRequest(object param)
        {
            AccommodationReservationRequestsService.Create(AccommodationReservation, NewArrivalDay, NewDepartureDay);
            var notificationManager = new NotificationManager();
            NotificationContent content = new NotificationContent { Title = "Success!", Message = "You succesfuly sent request for: " + AccommodationReservation.Accommodation.Name , Type = NotificationType.Success };
            notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            NavigationService.Navigate(new FisrtGuestAllRequests(NavigationService));
        }
    }
}
