using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	internal interface ITourReservationRepository : IRepository<TourReservation>
	{
		int NextId();
		TourReservation Add(TourReservation tourReservation);
		void DeleteByTourId(int id);
		List<TourReservation> GetReservationsByGuestId(int id);
	}
}
