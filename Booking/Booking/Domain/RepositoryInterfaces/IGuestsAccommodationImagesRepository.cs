using Booking.Domain.Model.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface IGuestsAccommodationImagesRepository : IRepository<GuestsAccommodationImages>
	{
		int NextId();
		void Add(GuestsAccommodationImages image);
	}
}
