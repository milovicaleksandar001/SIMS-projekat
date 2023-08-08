using Booking.Commands;
using Booking.Model;
using Booking.WPF.Views.Guest1;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class RenovationApprovalViewModel
    {

        public RelayCommand ButtonClickNo { get; set; }
        public RelayCommand ButtonClickYes { get; set; }
        public AccommodationReservation SelectedAccommodationReservation { get; set; }

        NavigationService NavigationService;

        public RenovationApprovalViewModel(AccommodationReservation selectedResrevation,NavigationService navigationService)
        {
            ButtonClickNo = new RelayCommand(ButtonNo);
            ButtonClickYes = new RelayCommand(ButtonYes);
            NavigationService = navigationService;
            SelectedAccommodationReservation = selectedResrevation;
        }

        public void ButtonNo(object param)
        {
            NavigationService.GoBack();
            var notificationManager = new NotificationManager();
            NotificationContent content = new NotificationContent { Title = "Congratulations!", Message = "You succesfuly rate your accommodation", Type = NotificationType.Success };
            notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
        }

        public void ButtonYes(object param)
        {
            NavigationService.Navigate(new RenovationSuggestions(SelectedAccommodationReservation, NavigationService));
        }
    }
}
