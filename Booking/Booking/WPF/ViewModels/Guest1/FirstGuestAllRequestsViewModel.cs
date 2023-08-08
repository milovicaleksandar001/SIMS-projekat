using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using Booking.WPF.Views.Guest1;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class FirstGuestAllRequestsViewModel : IObserver
    {
        public ObservableCollection<AccommodationReservationRequests> Requests { get; set; }
        public IAccommodationReservationRequestService _requestsService { get; set; }

        public AccommodationReservationRequests SelectedRequest { get; set; }

        public RelayCommand ClickShowMoreDetails { get; set; }

        public NavigationService NavigationService{ get; set; }

        public FirstGuestAllRequestsViewModel(NavigationService navigationService)
        {
            _requestsService = InjectorService.CreateInstance<IAccommodationReservationRequestService>();

            _requestsService.Subscribe(this);
            Requests = new ObservableCollection<AccommodationReservationRequests>(_requestsService.GetAll());

            ClickShowMoreDetails = new RelayCommand(ShowMoreDetails);
            NavigationService = navigationService;
        }

        public void ShowMoreDetails(object param)
        {
            if(SelectedRequest != null)
            {
                NavigationService.Navigate(new ShowRequestComment(SelectedRequest));
            }
            else
            {
                var notificationManager = new NotificationManager();
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Please select request!.", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
        }

        public void Update()
        {
            Requests.Clear();
            foreach (var request in _requestsService.GetAll())
            {
                Requests.Add(request);
            }
        }
    }
}
