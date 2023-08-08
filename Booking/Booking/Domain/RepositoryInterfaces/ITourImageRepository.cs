using Booking.Model;
using Booking.Model.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface ITourImageRepository : IRepository<TourImage>
	{
		int NextId();
		TourImage Add(TourImage tourImage);
		List<TourImage> GetTourImagesByTourId(int id);
		void DeleteByTourId(int id);
		TourImage GetByUrl(string url);
		void Delete(TourImage tourImage);

    }
}
