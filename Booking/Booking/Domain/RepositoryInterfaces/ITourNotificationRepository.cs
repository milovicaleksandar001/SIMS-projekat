using Booking.Domain.Model;

namespace Booking.Domain.RepositoryInterfaces
{
	internal interface ITourNotificationRepository : IRepository<TourNotification>
	{
		int NextId();
		TourNotification Add(TourNotification notification);
	}
}
