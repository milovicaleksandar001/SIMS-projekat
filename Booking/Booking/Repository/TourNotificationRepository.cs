using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Repository
{
	public class TourNotificationRepository : ITourNotificationRepository
	{
		private const string FilePath = "../../Resources/Data/tourNotifications.csv";

		private readonly Serializer<TourNotification> _serializer;

		private List<TourNotification> _notifications;

		public TourNotificationRepository()
		{
			_serializer = new Serializer<TourNotification>();
			_notifications = _serializer.FromCSV(FilePath);
		}

		public TourNotification Add(TourNotification notification)
		{
			_notifications = _serializer.FromCSV(FilePath);
			notification.Id = NextId();
			_notifications.Add(notification);
			_serializer.ToCSV(FilePath, _notifications);
			return notification;
		}

		public List<TourNotification> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}

		public TourNotification GetById(int id)
		{
			return _notifications.Find(n => n.Id == id);
		}

		public int NextId()
		{
			if (_notifications.Count == 0)
			{
				return 1;
			}
			else
			{
				return _notifications.Max(n => n.Id) + 1;
			}
		}
	}
}
