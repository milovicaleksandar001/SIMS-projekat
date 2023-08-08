using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Repository
{
	public class VoucherRepository : IVoucherRepository
	{
		private const string FilePath = "../../Resources/Data/vouchers.csv";

		private readonly Serializer<Voucher> _serializer;

		private List<Voucher> _vouchers;

		public VoucherRepository()
		{
			_serializer = new Serializer<Voucher>();
			_vouchers = _serializer.FromCSV(FilePath);
		}

		public List<Voucher> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}

		public Voucher GetById(int id)
		{
			return _vouchers.Find(v => v.Id == id);
		}

		public int NextId()
		{
			if (_vouchers.Count == 0)
			{
				return 1;
			}
			else
			{
				return _vouchers.Max(v => v.Id) + 1;
			}
		}

		public Voucher Add(Voucher voucher)
		{
			_vouchers = _serializer.FromCSV(FilePath);
			voucher.Id = NextId();
			_vouchers.Add(voucher);
			_serializer.ToCSV(FilePath, _vouchers);
			return voucher;
		}

		public List<Voucher> GetValidVouchersByUserId(int id)
		{
			List<Voucher> list = new List<Voucher>();
			foreach (Voucher voucher in _vouchers)
			{
				if (voucher.User.Id == id && voucher.IsActive && voucher.ValidTime > DateTime.Now)
				{
					list.Add(voucher);
				}
			}
			return list;
		}

		public Voucher Update(Voucher voucher)
		{
			Voucher founded = _vouchers.Find(v => v.Id == voucher.Id);
			founded = voucher;
			_serializer.ToCSV(FilePath, _vouchers);
			return founded;
		}
	}
}
