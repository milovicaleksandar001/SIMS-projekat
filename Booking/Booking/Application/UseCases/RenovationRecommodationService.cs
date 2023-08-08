using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Repository;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.UseCases
{
    public class RenovationRecommodationService : IRenovationRecommodationService
    {
        private readonly IRenovationRecommodationRepository _repository;
        private readonly IAccommodationResevationRepository _accommodationReservationRepostiory;
        private readonly List<IObserver> _observers; //ovo ne treba za sad

        public RenovationRecommodationService()
        {
            _observers = new List<IObserver>();
            _repository = InjectorRepository.CreateInstance<IRenovationRecommodationRepository>();
            _accommodationReservationRepostiory = InjectorRepository.CreateInstance<IAccommodationResevationRepository>();
        }

        public int NextId()
        {
            return _repository.NextId();
        }

        public void SaveReccommodation(RenovationRecommodation recommodation)
        {
            _repository.Add(recommodation);
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

    }
}
