using Booking.Observer;
using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model.DAO
{
    public class AccommodationGradeDAO: ISubject
    {
        private readonly AccommodationGradeRepository repository;
        private List<AccommodationGrade> accommodationGrades;
        private readonly List<IObserver> observers;
        private readonly AccommodationGradeRepository _accommodationGradeRepository;
        private AccommodationResevationRepository _accommodationReservationRepository;

        public AccommodationGradeDAO()
        {
            repository = new AccommodationGradeRepository();
            accommodationGrades = repository.Load();
            observers = new List<IObserver>();
            _accommodationGradeRepository = new AccommodationGradeRepository();
            _accommodationReservationRepository = new AccommodationResevationRepository();
            BindGradesToReservations();
        }

        public List<AccommodationGrade> FindAllGrades()
        {
            return accommodationGrades;
        }

        public AccommodationGrade FindById(int id)
        {
            return accommodationGrades.Find(v => v.Id == id);
        }
        public int NextId()
        {
            if (accommodationGrades.Count == 0)
            {
                return 1;
            }
            else
            {
                return accommodationGrades.Max(t => t.Id) + 1;
            }
        }

        public AccommodationGrade Create(AccommodationGrade accommodationGrade)
        {
            accommodationGrade.Id = NextId();
            accommodationGrades.Add(accommodationGrade);
            _accommodationGradeRepository.Save(accommodationGrades);
            NotifyObservers();
            return accommodationGrade;
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
        public void BindGradesToReservations()
        {
            foreach (AccommodationGrade accommodationGrade in accommodationGrades)
            {
                foreach (AccommodationReservation accommodationReservation in _accommodationReservationRepository.Load())
                {
                    if (accommodationReservation.Id == accommodationGrade.Accommodation.Id)
                    {
                        accommodationGrade.Accommodation = accommodationReservation;
                    }
                }
            }

        }
        public bool IsReservationGraded(int accommodationReservationId)
        {
            foreach (var grade in accommodationGrades)
            {
                if (grade.Accommodation.Id == accommodationReservationId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
