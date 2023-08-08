using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using System.Collections.Generic;

namespace Booking.Service
{
	public class TourGuestsService : ITourGuestsService
	{
		private readonly ITourGuestsRepository _repository;
		private readonly ITourRepository _tourRepository;
		private List<IObserver> _observers;

		public TourGuestsService()
		{
			_repository = InjectorRepository.CreateInstance<ITourGuestsRepository>();
			_tourRepository = InjectorRepository.CreateInstance<ITourRepository>();
			_observers = new List<IObserver>();
		}

		public TourGuests AddTourGuests(TourGuests tourGuests)
		{
			//_repository.Add(tourGuests);
			//NotifyObservers();
			//return tourGuests;

			return _repository.Add(tourGuests);
		}

		public void Create(TourGuests tourGuests)
		{
			AddTourGuests(tourGuests);
		}

		public List<TourGuests> GetAll()
		{
			return _repository.GetAll();
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

		public TourGuests UpdateTourGuest(TourGuests tourGuests)
		{
			return _repository.Update(tourGuests);
		}

		public TourGuests CheckPresence(int id)
		{
			List<TourGuests> list = _repository.GetByUserId(id);
			foreach (TourGuests tourGuest in list)
			{
				tourGuest.Tour = _tourRepository.GetById(tourGuest.Tour.Id);
				if (tourGuest.Tour.IsStarted == true)
				{
					return tourGuest;
				}
			}
			return null;
		}
	}
}
