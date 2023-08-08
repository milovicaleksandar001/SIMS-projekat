using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface IAccommodationRepository : IRepository<Accommodation>
	{
		int NextId();
		Accommodation Add(Accommodation accommodation);
	}
}
