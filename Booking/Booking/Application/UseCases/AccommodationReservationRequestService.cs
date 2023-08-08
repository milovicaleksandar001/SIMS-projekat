using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Model.Enums;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Repository;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.Service
{
    public class AccommodationReservationRequestService : IAccommodationReservationRequestService
    {
        private readonly List<IObserver> _observers;
        private readonly IAccommodationReservationRequestsRepostiory _repository;
        private readonly IAccommodationResevationRepository _reservationRepository;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;

        public AccommodationReservationRequestService()
        {
           
            _observers = new List<IObserver>();
            _repository = InjectorRepository.CreateInstance<IAccommodationReservationRequestsRepostiory>();
            _reservationRepository = InjectorRepository.CreateInstance<IAccommodationResevationRepository>();
            _accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
            _locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
        }
        public List<AccommodationReservationRequests> GetAll()
        {
            List<AccommodationReservationRequests> accommodationReservationRequestAll = new List<AccommodationReservationRequests>();
            List<AccommodationReservationRequests> accommodationReservationRequestList = new List<AccommodationReservationRequests>();
            accommodationReservationRequestAll = _repository.GetAll();
            foreach (var arr in accommodationReservationRequestAll)
            {
                arr.AccommodationReservation = _reservationRepository.GetById(arr.AccommodationReservation.Id);
                if(arr.AccommodationReservation.Guest.Id == AccommodationReservationService.SignedFirstGuestId) 
                {
                    accommodationReservationRequestList.Add(arr);
                }
            }

            foreach (var arr in accommodationReservationRequestList)
            {
                arr.AccommodationReservation.Accommodation = _accommodationRepository.GetById(arr.AccommodationReservation.Accommodation.Id);
                arr.AccommodationReservation.Accommodation.Location = _locationRepository.GetById(arr.AccommodationReservation.Accommodation.Location.Id);
                arr.AccommodationReservation.Accommodation.Owner = _userRepository.GetById(arr.AccommodationReservation.Accommodation.Owner.Id);
            }
            return accommodationReservationRequestList;
        }
        public List<AccommodationReservationRequests> GetSeeableDateChanges() 
        {
            List<AccommodationReservationRequests> accommodationReservationRequestAll = new List<AccommodationReservationRequests>();
            List<AccommodationReservationRequests> accommodationReservationRequestList = new List<AccommodationReservationRequests>();
            accommodationReservationRequestAll = _repository.GetAll();
            foreach (var arr in accommodationReservationRequestAll)
            {
                arr.AccommodationReservation = _reservationRepository.GetById(arr.AccommodationReservation.Id);
                arr.AccommodationReservation.Accommodation = _accommodationRepository.GetById(arr.AccommodationReservation.Accommodation.Id);
                if (arr.AccommodationReservation.Accommodation.Owner.Id == AccommodationService.SignedOwnerId && arr.Status.ToString().Equals("PENDNING"))
                {
                    arr.Accessable = CheckDate(arr);
                    accommodationReservationRequestList.Add(arr);
                }
            }
            return accommodationReservationRequestList;
        }
        public String CheckDate(AccommodationReservationRequests request) 
        {
            List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
            accommodationReservations = _reservationRepository.GetAll();
            foreach (var reservation in accommodationReservations) 
            {
                reservation.Accommodation = _accommodationRepository.GetById(reservation.Accommodation.Id);
                for (DateTime date = request.NewArrivalDay; date <= request.NewDeparuteDay; date=date.AddDays(1)) 
                {
                    for (DateTime reservationDate = reservation.ArrivalDay; reservationDate <= reservation.DepartureDay; reservationDate=reservationDate.AddDays(1)) 
                    {
                        if (date.Equals(reservationDate) && reservation.Accommodation.Id == request.AccommodationReservation.Accommodation.Id) 
                        {
                            return "Ocupied";
                        }
                    }
                }
            }
            return "Free";
        }

        public void SaveRejected(AccommodationReservationRequests request) 
        {
            List<AccommodationReservationRequests> accommodationReservationRequestAll = new List<AccommodationReservationRequests>();
            accommodationReservationRequestAll = _repository.GetAll();
            foreach (var arr in accommodationReservationRequestAll)
            {
                if (arr.Id == request.Id) 
                {
                    arr.Comment=request.Comment;
                    arr.Status = RequestStatus.DECLINED;
                }
            }
            _repository.Save(accommodationReservationRequestAll);
        }
        public void SaveAccepted(AccommodationReservationRequests request)
        {
            List<AccommodationReservationRequests> accommodationReservationRequestAll = new List<AccommodationReservationRequests>();
            accommodationReservationRequestAll = _repository.GetAll();
            foreach (var arr in accommodationReservationRequestAll)
            {
                if (arr.Id == request.Id)
                {
                    arr.Status = RequestStatus.ACCEPTED;
                }
            }
            _repository.Save(accommodationReservationRequestAll);
            List<AccommodationReservation> allReservations = new List<AccommodationReservation>();
            allReservations = _reservationRepository.GetAll();
            AccommodationReservation accommodationReservation = new AccommodationReservation();
            foreach (var reservation in allReservations)
            {
                if (reservation.Id == request.AccommodationReservation.Id)
                {
                    accommodationReservation.ArrivalDay = request.NewArrivalDay;
                    accommodationReservation.DepartureDay = request.NewDeparuteDay;
                    accommodationReservation.Accommodation.Id = reservation.Accommodation.Id;
                    accommodationReservation.Guest.Id = reservation.Guest.Id;
                    _reservationRepository.Add(accommodationReservation);
                    _reservationRepository.Delete(reservation);
                }
            }
        }

            public void DeleteRequest(AccommodationReservation selectedReservation)
        {
            _repository.DeleteRequest(selectedReservation);
            NotifyObservers();
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

        public void Create(AccommodationReservation selectedResrevation, DateTime newArrivalDay,DateTime newDepartureDay)
        {
            _repository.Add(selectedResrevation, newArrivalDay, newDepartureDay);
            NotifyObservers();
        }
    }
}
