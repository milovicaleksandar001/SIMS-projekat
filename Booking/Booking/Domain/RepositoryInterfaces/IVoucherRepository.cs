using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
	internal interface IVoucherRepository : IRepository<Voucher>
	{
		int NextId();
		Voucher Add(Voucher voucher);
		List<Voucher> GetValidVouchersByUserId(int id);
		Voucher Update(Voucher voucher);
	}
}
