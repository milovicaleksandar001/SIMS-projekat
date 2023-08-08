using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Repository;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.UseCases
{
    public class SuperGuestService: ISuperGuestService
    {
        public readonly ISuperGuestRepository _repository;
        public readonly IUserRepository _userRepository;
        public readonly IAccommodationResevationRepository _accommodationResevationRepository;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly ILocationRepository _locationRepository;

        public SuperGuestService()
        {
            _repository = InjectorRepository.CreateInstance<ISuperGuestRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
            _accommodationResevationRepository = InjectorRepository.CreateInstance<IAccommodationResevationRepository>();
            _accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
            _locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
        }

        public List<AccommodationReservation> GetGeustsReservatonst(User SignedGuest)
        {
            List<AccommodationReservation> _guestsReservations = new List<AccommodationReservation>();

            foreach (var reservation in _accommodationResevationRepository.GetAll())
            {
                if (reservation.Guest.Id == SignedGuest.Id)
                {
                    reservation.Accommodation = _accommodationRepository.GetById(reservation.Accommodation.Id);
                    reservation.Accommodation.Location = _locationRepository.GetById(reservation.Accommodation.Location.Id);
                    reservation.Accommodation.Owner = _userRepository.GetById(reservation.Accommodation.Owner.Id);
                    reservation.Guest = _userRepository.GetById(SignedGuest.Id);
                    _guestsReservations.Add(reservation);
                }
            }
            return _guestsReservations;
        }

        public DateTime SetActivationDate(User SignedGuest)
        {
            List<AccommodationReservation> _guestsReservations = GetGeustsReservatonst(SignedGuest);

            List<AccommodationReservation> copyReservations = new List<AccommodationReservation>();

            foreach(var r in _guestsReservations)
            {
                if(r.DepartureDay.AddYears(1) > DateTime.Now && r.DepartureDay.Date <= DateTime.Now)
                {
                    copyReservations.Add(r);
                }
            }

            copyReservations = copyReservations.OrderBy(r => r.DepartureDay).ToList();

            return copyReservations[9].DepartureDay;
 
        }

        public void CreateSuperGuest(User signedGuest, int numberOfReservations)
        {
            signedGuest.Super = 1;
            _userRepository.Update(signedGuest);

            SuperGuest superGuest = new SuperGuest();
            superGuest.BonusPoints = 5;
            superGuest.NumberOfReservations = numberOfReservations;
            superGuest.ActivationDate = SetActivationDate(signedGuest);
            superGuest.Guest = signedGuest;

            _repository.Add(superGuest);
        }

        public int CalculateReservationsForLastYear(User SignedGuest)
        {
            List<AccommodationReservation> _guestsReservations = GetGeustsReservatonst(SignedGuest);

            int countNumberOfReservations = 0;

            foreach (var reservation in _guestsReservations)
            {
                if (reservation.DepartureDay.AddYears(1) > DateTime.Now && reservation.DepartureDay.Date < DateTime.Now)
                {
                    countNumberOfReservations++;
                }
            }
            return countNumberOfReservations;
        }

        public void CheckNumberOfReservations(User SignedGuest)
        {
         
            int numberOfReservations = CalculateReservationsForLastYear(SignedGuest);

            if (numberOfReservations >= 10)
            {
                CreateSuperGuest(SignedGuest, numberOfReservations);
            }
        }

        public void SetOrdinaryGuest(SuperGuest superGuest, User signedGuest)
        {
            _repository.Delete(superGuest);
            signedGuest.Super = 0;
            _userRepository.Update(signedGuest);
        }

        public void UpdateSuperGuest(User SignedGuest, int numReservatios)
        {
            SuperGuest superGuest = _repository.GetSuperBySignedGuestId(SignedGuest.Id);
            superGuest.BonusPoints = 5;
            superGuest.ActivationDate = SetActivationDate(SignedGuest);
            _repository.Update(superGuest);
        }

        public void CheckSuperAgain(User SignedGuest)
        {
            int numberOfReservations = CalculateReservationsForLastYear(SignedGuest);
            SuperGuest superGuest = _repository.GetSuperBySignedGuestId(SignedGuest.Id);

            if (numberOfReservations >= 10)
            {
                UpdateSuperGuest(SignedGuest, numberOfReservations);
            }
            else
            {
                SetOrdinaryGuest(superGuest, SignedGuest);
            }
        }

        public void CheckActivationDate(User SignedGuest)
        {
            SuperGuest superGuest = _repository.GetSuperBySignedGuestId(SignedGuest.Id);

            if (superGuest.ActivationDate.AddYears(1) <= DateTime.Now)
            {
                CheckSuperAgain(SignedGuest);
            }
        }

        public void CheckSuperGuest()
        {
            User SignedGuest = _userRepository.GetById(AccommodationReservationService.SignedFirstGuestId);

            if(SignedGuest.Super != 1)
            {
                CheckNumberOfReservations(SignedGuest);
            }
            else
            {
                CheckActivationDate(SignedGuest);
            }
        }

        public void ReduceBonusPoints()
        {
            User SignedGuest = _userRepository.GetById(AccommodationReservationService.SignedFirstGuestId);
            
            if(SignedGuest.Super == 1)
            {
                SuperGuest SuperGuest = _repository.GetSuperBySignedGuestId(SignedGuest.Id);
                if (SuperGuest.BonusPoints > 0)
                {
                    SuperGuest.BonusPoints -= 1;
                    _repository.Update(SuperGuest);
                }
            }
        }

        public SuperGuest GetSuperBySignedGuestId(int id)
        {
           return _repository.GetSuperBySignedGuestId(id);
        }
    }
}
