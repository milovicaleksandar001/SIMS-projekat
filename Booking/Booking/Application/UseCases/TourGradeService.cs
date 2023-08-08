using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Service
{
    public class TourGradeService : ITourGradeService
    {
        private readonly List<IObserver> _observers;
        private readonly ITourGradeRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ITourKeyPointRepository _keyPointRepository;
        private readonly ITourGuestsRepository _tourGuestsRepository;
        private readonly ITourRepository _tourRepository;
        private readonly ILocationRepository _locationRepository;
        public TourGradeService() 
        { 
        _repository = InjectorRepository.CreateInstance<ITourGradeRepository>();
        _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
        _keyPointRepository = InjectorRepository.CreateInstance<ITourKeyPointRepository>();
        _tourGuestsRepository = InjectorRepository.CreateInstance<ITourGuestsRepository>();
        _tourRepository = InjectorRepository.CreateInstance<ITourRepository>();
        _locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();

        _observers = new List<IObserver>();
        }

        public List<TourGrade> GetAll()
        {
            return _repository.GetAll();
        }

        public TourGrade GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<TourGrade> GetGuideGrades()
        {
            List <TourGrade> lista = new List<TourGrade>();
            foreach (TourGrade tg in _repository.GetAll()) 
            {
                User pomUser = _userRepository.GetById(tg.Guest.Id);
                Tour pomTour = _tourRepository.GetById(tg.Tour.Id);

                foreach (TourGuests tourGuests in _tourGuestsRepository.GetAll())
                {
                    if (tourGuests.User.Id == pomUser.Id && tourGuests.Tour.Id == tg.Tour.Id)
                    {
                        TourKeyPoint pomTourKeypoint = _keyPointRepository.GetById(tourGuests.TourKeyPoint.Id);
                        tg.keyPointJoined = pomTourKeypoint;
                        Location pomLocation = _locationRepository.GetById(pomTourKeypoint.Location.Id);
                        tg.keyPointJoined.Location = pomLocation;
                        tg.StateAndCity = pomLocation.State.ToString() + ", " + pomLocation.City;
                    }
                }

                if (tg.Guide.Id == TourService.SignedGuideId)
                {
                    tg.Guest = pomUser;
                    tg.Tour = pomTour;
                    lista.Add(tg);
                }
            }
            return lista;
        }

        public TourGrade UpdateTourGrade(TourGrade grade) 
        { 
        TourGrade oldTourGrade = _repository.GetById(grade.Id);
            if(oldTourGrade == null) return null;

            oldTourGrade.Valid = grade.Valid;
            return _repository.Update(grade);
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

        public TourGrade AddTourGrade(TourGrade tourGrade)
        {
            return _repository.Add(tourGrade);
        }

        public List<TourGrade> GetGradesByGuestId(int id)
        {
            return _repository.GetAllByGuestId(id);
        }
    }
}
