using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface IAccommodationAndOwnerGradeRepository : IRepository<AccommodationAndOwnerGrade>
	{
		int NextId();
		void Add(AccommodationAndOwnerGrade grade);
	}
}
