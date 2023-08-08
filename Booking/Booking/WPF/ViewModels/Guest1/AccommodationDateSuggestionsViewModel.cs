using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using Booking.View;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class AccommodationDateSuggestionsViewModel
    {
        public ObservableCollection<Range> Ranges { get; set; }

        public Range SelectedDates { get; set; }

        public Accommodation SelectedAccommodation { get; set; }

        public String AccommodationLabel { get; set; } = String.Empty;

        public IAccommodationReservationService AccommodationReservationService { get; set; }

        public RelayCommand Button_Click_ReserveDate { get; set; }

        public AccommodationDateSuggestionsViewModel(List<(DateTime, DateTime)> ranges, Accommodation selectedAccommodation)
        {

            Ranges = new ObservableCollection<Range>(ranges.Select(r => new Range { StartDate = r.Item1, EndDate = r.Item2 }).ToList());
            SelectedAccommodation = selectedAccommodation;
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            AccommodationLabel = SetAccommodationLabel();
            Button_Click_ReserveDate = new RelayCommand(ButtonReserveDate);
        }

        private String SetAccommodationLabel()
        {
            return SelectedAccommodation.Name + "-" + SelectedAccommodation.Location.State + "-" + SelectedAccommodation.Location.City + SelectedAccommodation.Location.State;
        }

        private void ButtonReserveDate(object param)
        {
            var notificationManager = new NotificationManager();
            if (SelectedDates == null)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "You have to select dates you want to reserve!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else
            {
                //Uvezati gosta?
                AccommodationReservation newReservation = new AccommodationReservation(SelectedAccommodation, SelectedDates.StartDate, SelectedDates.EndDate, AccommodationReservationService.GetSignedInFirstGuest());

                AccommodationReservationService.SaveReservation(newReservation);

                
                NotificationContent content = new NotificationContent { Title = "Congratulations!", Message = "You succesfuly reserve your accommodation for: " + SelectedDates.StartDate.ToString("dd/MM/yyyy") + " - " + SelectedDates.EndDate.ToString("dd/MM/yyyy") + " !", Type = NotificationType.Success };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
    }
}

    public class Range
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
