using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Serializer;
using Booking.Util;
using System.Collections.Generic;

namespace Booking.Service
{
	public class VoucherService : IVoucherService
	{
		private readonly IVoucherRepository _voucherRepository;

		private readonly List<IObserver> _observers;

		public VoucherService()
		{
			_voucherRepository = InjectorRepository.CreateInstance<IVoucherRepository>();
			_observers = new List<IObserver>();
		}

		public Voucher AddVoucher(Voucher voucher)
		{
			return _voucherRepository.Add(voucher);
		}
        public List<Voucher> GetAll()
        {
            return _voucherRepository.GetAll();
        }

        public List<Voucher> GetUserVouchers(int id)
        {
			List<Voucher> vouchers = new List<Voucher>();	

			foreach(Voucher voucher in _voucherRepository.GetAll())
			{
				if(voucher.User.Id == id)
				{
					vouchers.Add(voucher);
				}	
			}
            return vouchers;
        }

        public Voucher GetById(int id)
        {
			return _voucherRepository.GetById(id);
        }

        public void Create(Voucher voucher)
		{
			AddVoucher(voucher);
			NotifyObservers();
		}

		public Voucher Update(Voucher voucher) 
		{
			return _voucherRepository.Update(voucher);
		}

		public void NotifyObservers()
		{
			foreach (var observer in _observers)
			{
				observer.Update();
			}
		}
		public void Subscribe(IObserver observer)
		{
			_observers.Add(observer);
		}

		public void Unsubscribe(IObserver observer)
		{
			_observers.Remove(observer);
		}

		public List<Voucher> GetVouchersByUserId(int id)
		{
			return _voucherRepository.GetValidVouchersByUserId(id);
		}

		public void RedeemVoucher(Voucher voucher)
		{
			voucher.IsActive = false;
			_voucherRepository.Update(voucher);
		}
	}
}
