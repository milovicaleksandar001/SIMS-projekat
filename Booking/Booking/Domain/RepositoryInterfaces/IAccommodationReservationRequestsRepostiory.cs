using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface IAccommodationReservationRequestsRepostiory : IRepository<AccommodationReservationRequests>
	{
		int NextId();
		void DeleteRequest(AccommodationReservation selectedReservation);
		void Add(AccommodationReservation selectedResrevation, DateTime newArrivalDay, DateTime newDepartureDay);
		void Save(List<AccommodationReservationRequests> list);
	}
}
