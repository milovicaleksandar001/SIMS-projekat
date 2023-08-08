using Booking.Domain.Model;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
	public interface ITourNotificationService : IService<TourNotification>
	{
		List<TourNotification> GetAll();
		List<TourNotification> GetByUserId(int id);
		TourNotification Add(TourNotification tn);
	}
}
