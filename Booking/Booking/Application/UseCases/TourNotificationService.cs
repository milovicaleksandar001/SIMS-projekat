using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using System;
using System.Collections.Generic;

namespace Booking.Application.UseCases
{
	public class TourNotificationService : ITourNotificationService
	{
		private readonly ITourNotificationRepository _tourNotificationRepository;
		private readonly ITourRepository _tourRepository;
		private readonly ILocationRepository _locationRepository;

		public TourNotificationService()
		{
			_tourNotificationRepository = InjectorRepository.CreateInstance<ITourNotificationRepository>();
			_tourRepository = InjectorRepository.CreateInstance<ITourRepository>();
			_locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
		}

		public List<TourNotification> GetAll()
		{
			List<TourNotification> tourNotifications = new List<TourNotification>();
			foreach (var tn in _tourNotificationRepository.GetAll())
			{
				tn.Tour = _tourRepository.GetById(tn.Tour.Id);
				tn.Tour.Location = _locationRepository.GetById(tn.Tour.Location.Id);
				tourNotifications.Add(tn);
			}
			return tourNotifications;
		}

		public List<TourNotification> GetByUserId(int id)
		{
			List<TourNotification> tourNotifications = new List<TourNotification>();

			foreach (var tn in GetAll())
			{
				if (tn.User.Id == id)
				{
					tourNotifications.Add(tn);
				}
			}

			tourNotifications.Reverse();

			return tourNotifications;
		}

		public TourNotification Add(TourNotification tn)
		{
			tn.Id = _tourNotificationRepository.NextId();
			tn.Message = "New tour created by request";
			tn.IsRead = false;
			tn.CreatedTime = DateTime.Now;
			return _tourNotificationRepository.Add(tn);
		}
	}
}
