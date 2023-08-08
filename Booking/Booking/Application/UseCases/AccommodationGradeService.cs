using Booking.Observer;
using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using Booking.Domain.RepositoryInterfaces;

namespace Booking.Service
{
    public class AccommodationGradeService : IAccommodationGradeService
    {
        private readonly List<IObserver> _observers;
        private readonly IAccommodationGradeRepository _repository;
        private IAccommodationResevationRepository _accommodationReservationRepository;
        private IAccommodationRepository _accommodationRepository;
        private IUserRepository _userRepository;
        private IAccommodationAndOwnerGradeRepository _accommodationAndOwnerGradeRepository;


        public AccommodationGradeService()
        {
            _repository = InjectorRepository.CreateInstance<IAccommodationGradeRepository>();
            _observers = new List<IObserver>();
            _accommodationReservationRepository = InjectorRepository.CreateInstance<IAccommodationResevationRepository>();
            _accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
            _accommodationAndOwnerGradeRepository = InjectorRepository.CreateInstance<IAccommodationAndOwnerGradeRepository>();
        }
        public List<AccommodationGrade> GetAll()
        {
            return _repository.GetAll();
        }
        public AccommodationGrade Create(AccommodationGrade accommodationGrade)
        {
            _repository.Add(accommodationGrade);
            //NotifyObservers();
            return accommodationGrade;
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
        
        public bool IsReservationGraded(int accommodationReservationId)
        {
            return _repository.IsReservationGraded(accommodationReservationId);
        }

        public List<AccommodationGrade> GetSeeableGrades()
        {
            List<AccommodationGrade> _seeableGrades = new List<AccommodationGrade>();
            foreach (var g in _repository.GetAll())
            {
                g.Accommodation = _accommodationReservationRepository.GetById(g.Accommodation.Id);
                g.Accommodation.Accommodation = _accommodationRepository.GetById(g.Accommodation.Accommodation.Id);
                g.Accommodation.Accommodation.Owner = _userRepository.GetById(g.Accommodation.Accommodation.Owner.Id);
               
                if (g.Accommodation.Guest.Id == AccommodationReservationService.SignedFirstGuestId)
                {
                    foreach (var go in _accommodationAndOwnerGradeRepository.GetAll())
                    {
                        if (g.Accommodation.Id == go.AccommodationReservation.Id)
                        {
                            _seeableGrades.Add(g);
                        }
                    }
                }
            }
            return _seeableGrades;
        }
    }
}
