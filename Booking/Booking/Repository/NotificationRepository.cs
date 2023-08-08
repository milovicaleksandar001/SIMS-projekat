using Booking.Domain.Model;
using Booking.Domain.Model.Images;
using Booking.Domain.RepositoryInterfaces;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private const string FilePath = "../../Resources/Data/notifications.csv";

        private readonly Serializer<Notification> _serializer;

        public List<Notification> _notifications;


        public NotificationRepository()
        {
            _notifications = new List<Notification>();
            _serializer = new Serializer<Notification>();
            _notifications = _serializer.FromCSV(FilePath);
        }
        public List<Notification> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Notification GetById(int id)
        {
            return _notifications.Find(a => a.Id == id);
        }

        public int NextId()
        {
            int maxId = 0;
            foreach (Notification notification in _notifications)
            {
                if (notification.Id > maxId)
                {
                    maxId = notification.Id;
                }
            }
            return maxId + 1;
        }

        public void Add(Notification notification)
        {
            notification.Id = NextId();
            _notifications.Add(notification);
            _serializer.ToCSV(FilePath, _notifications);
        }

        public void SaveChanges(Notification notification)
        {
            Notification existingNotification = _notifications.Find(n => n.Id == notification.Id);
            if (existingNotification != null)
            {
                int index = _notifications.IndexOf(existingNotification);
                _notifications[index] = notification;
                _serializer.ToCSV(FilePath, _notifications);
            }
        }
    }
}
