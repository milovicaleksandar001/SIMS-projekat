using Booking.Domain.Model;
using Booking.Model;
using Booking.Model.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface INotificationService : IService<Notification>
    {
        List<Notification> GetUserNotifications(User user);
        void CreateCancellationNotification(Notification notification);
        void ChangeNotificationState(Notification notification);
        void SendNotification(List<Notification> notifications, User user);
        void SendToastNotification(User user);
        void MakeReject(AccommodationReservationRequests SelectedAccommodationReservationRequest);
        void MakeAccepted(AccommodationReservationRequests SelectedAccommodationReservationRequest);
        void MakeCancellationNotification(AccommodationReservation SelectedReservation);
    }
}
