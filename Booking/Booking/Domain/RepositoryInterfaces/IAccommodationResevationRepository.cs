using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface IAccommodationResevationRepository : IRepository<AccommodationReservation>
	{
		int NextId();
		void Add(AccommodationReservation reservation);
		void Delete(AccommodationReservation selectedReservation);
		void Save(List<AccommodationReservation> list);
		List<AccommodationReservation> GetAllWithDeleted();
	}
}
