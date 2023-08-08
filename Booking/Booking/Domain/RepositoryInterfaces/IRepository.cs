using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface IRepository<T>
	{
		List<T> GetAll();
		T GetById(int id);
	}
}
