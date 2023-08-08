using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.UseCases
{
    public class AccommodationRenovationService : ISubject, IAccommodationRenovationService
    {
        private readonly List<IObserver> _observers;
        private readonly IAccommodationRenovationRepository _repository;
        private IAccommodationRepository _accommodationRepository;
        public AccommodationRenovationService()
        {
            _observers = new List<IObserver>();
            _repository = InjectorRepository.CreateInstance<IAccommodationRenovationRepository>();
            _accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
        }
        public AccommodationRenovation GetById(int id)
        {
            AccommodationRenovation accommodationRenovation = new AccommodationRenovation();
            accommodationRenovation = _repository.GetById(id);
            accommodationRenovation.Accommodation = _accommodationRepository.GetById(accommodationRenovation.Accommodation.Id);
            return accommodationRenovation;
        }
        public void SaveRenovation(AccommodationRenovation renovation)
        {
            _repository.Add(renovation);
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
        public List<AccommodationRenovation> GetSeeableRenovations()
        {
            List<AccommodationRenovation> _seeableRenovations = new List<AccommodationRenovation>();
            foreach (var r in _repository.GetAll())
            {
                r.Accommodation = _accommodationRepository.GetById(r.Accommodation.Id);

                if (r.Accommodation.Owner.Id == AccommodationService.SignedOwnerId) 
                {
                    _seeableRenovations.Add(r);
                }
            }
            return _seeableRenovations;
        }
        public void Delete(AccommodationRenovation selectedRenovation)
        {
            _repository.Delete(selectedRenovation);
            NotifyObservers();
        }
    }
}
