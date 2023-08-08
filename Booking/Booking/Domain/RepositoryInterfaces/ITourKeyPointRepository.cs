using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface ITourKeyPointRepository : IRepository<TourKeyPoint>
	{
		int NextId();
		TourKeyPoint Add(TourKeyPoint keyPoint);
		TourKeyPoint Update(TourKeyPoint keyPoint);
		List<TourKeyPoint> GetKeyPointsByTourId(int id);
		void DeleteByTourId(int id);
		void DeleteById(int id);

    }
}
