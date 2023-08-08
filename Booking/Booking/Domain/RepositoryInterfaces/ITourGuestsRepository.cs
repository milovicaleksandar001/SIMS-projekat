using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface ITourGuestsRepository : IRepository<TourGuests>
	{
		//int NextId();
		TourGuests Add(TourGuests tourGuest);
		void DeleteByTourId(int id);
		TourGuests Update(TourGuests tourGuests);
		List<TourGuests> GetByUserId(int id);
	}
}
