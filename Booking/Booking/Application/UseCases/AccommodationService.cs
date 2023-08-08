using Booking.Domain.Model;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.Service
{
    public class AccommodationService : ISubject, IAccommodationService
    {
        private readonly List<IObserver> _observers;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccommodationImagesRepository _accommodationImagesRepository;
        private readonly IAccommodationRenovationRepository _accommodationRenovationRepository;
        public static int SignedOwnerId;

        public AccommodationService()
        {
            _observers = new List<IObserver>();
            _accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
            _locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
            _accommodationRenovationRepository = InjectorRepository.CreateInstance<IAccommodationRenovationRepository>();

            _accommodationImagesRepository = InjectorRepository.CreateInstance<IAccommodationImagesRepository>();
        }
        public int GetSignedInOwner()
        {
            return SignedOwnerId;
        }

        public List<Accommodation> GetAll() 
        {
            List<Accommodation> accommodationList = new List<Accommodation>();
            accommodationList = _accommodationRepository.GetAll();
            foreach (var a in accommodationList) 
            {
                a.Location = _locationRepository.GetById(a.Location.Id);
                a.Owner = _userRepository.GetById(a.Owner.Id);
                foreach (var p in _accommodationImagesRepository.GetAll()) 
                {
                    if (p.Accomodation.Id == a.Id)
                    {
                        a.Images.Add(p);
                    }
                }
            }
            return accommodationList;
        }
        public List<Accommodation> GetAllSuper()
        {
            List<Accommodation> accommodationList = new List<Accommodation>();
            accommodationList = _accommodationRepository.GetAll();
            List<AccommodationRenovation> renovationList = new List<AccommodationRenovation>();
            renovationList = _accommodationRenovationRepository.GetAll();
            foreach (var r in renovationList)
            {
                r.Accommodation = _accommodationRepository.GetById(r.Accommodation.Id);
            }
            foreach (var a in accommodationList)
            {
                a.Location = _locationRepository.GetById(a.Location.Id);
                a.Owner = _userRepository.GetById(a.Owner.Id);
                foreach (var p in _accommodationImagesRepository.GetAll())
                {
                    if (p.Accomodation.Id == a.Id)
                    {
                        a.Images.Add(p);
                    }
                }
                if (a.Owner.Super == 1) 
                {
                    a.Name = a.Name + "*";
                }
                foreach (var r in renovationList) 
                {
                    if (!a.Name.Contains("(renovated)") && a.Id == r.Accommodation.Id && r.EndDay.AddYears(1) > DateTime.Now && r.EndDay < DateTime.Now)
                    {
                        a.Name = a.Name + "(renovated)";
                    }
                }
            }
            return accommodationList;
        }
        public bool IsAccommodationTypeValid(Accommodation accommodation, List<String> accommodationTypes)
        {
            bool info = false;

            if (accommodationTypes.Count == 0)
            {
                return true;
            }
            foreach (String type in accommodationTypes)
            {
                if (accommodation.Type.ToString().Contains(type))
                {
                    info = true;
                    break;
                }
            }
            return info;
        }
        public bool IsCapasityValid(string numberOfGuests, Accommodation accommodation)
        {
            return string.IsNullOrEmpty(numberOfGuests) || int.Parse(numberOfGuests) <= accommodation.Capacity;
        }

        public bool IsCityValid(string city, Accommodation accommodation)
        {
            return string.IsNullOrEmpty(city) || accommodation.Location.City.ToLower().Contains(city.ToLower());
        }

        public bool IsStateValid(string state, Accommodation accommodation)
        {
            return string.IsNullOrEmpty(state) || state.Equals("All") || accommodation.Location.State.ToLower().Contains(state.ToLower());
        }

        public bool IsNameValid(string name, Accommodation accommodation)
        {
            return string.IsNullOrEmpty(name) || accommodation.Name.ToLower().Contains(name.ToLower());
        }

        public bool IsMinNumberOfDaysValid(string minNumDaysOfReservation, Accommodation accommodation)
        {
            return string.IsNullOrEmpty(minNumDaysOfReservation) || int.Parse(minNumDaysOfReservation) >= accommodation.MinNumberOfDays;
        }

        public void Search(ObservableCollection<Accommodation> observe, string name, string city, string state, List<string> accommodationTypes, string numberOfGuests, string minNumDaysOfReservation)
        {
            observe.Clear();

            foreach (Accommodation accommodation in _accommodationRepository.GetAll())
            {
                //binding
                accommodation.Location = _locationRepository.GetById(accommodation.Location.Id);

                foreach (var p in _accommodationImagesRepository.GetAll())
                {
                    if (p.Accomodation.Id == accommodation.Id)
                    {
                        accommodation.Images.Add(p);
                    }
                }

                if (IsNameValid(name, accommodation) && IsStateValid(state, accommodation) && IsAccommodationTypeValid(accommodation, accommodationTypes) && IsCityValid(city, accommodation) && IsCapasityValid(numberOfGuests, accommodation) && IsMinNumberOfDaysValid(minNumDaysOfReservation, accommodation))
                {
                    observe.Add(accommodation);
                }
            }

        }

        public void ShowAll(ObservableCollection<Accommodation> accommodationsObserve)
        {
            accommodationsObserve.Clear();

            foreach (Accommodation accommodation in _accommodationRepository.GetAll())
            {
                //binding
                accommodation.Location = _locationRepository.GetById(accommodation.Location.Id);
                foreach (var p in _accommodationImagesRepository.GetAll())
                {
                    if (p.Accomodation.Id == accommodation.Id)
                    {
                        accommodation.Images.Add(p);
                    }
                }
                accommodationsObserve.Add(accommodation);
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

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
        
        public Accommodation AddAccommodation(Accommodation accommodation)
        {

            accommodation.Owner.Id = SignedOwnerId;
            _accommodationRepository.Add(accommodation);
            foreach (var picture in accommodation.Images)
            {
                picture.Accomodation = accommodation;
                _accommodationImagesRepository.Add(picture);
            }
            NotifyObservers();
            return accommodation;
        }

        public List<Accommodation> GetOwnerAccommodations()
        {
            List<Accommodation> _ownerAccommodations = new List<Accommodation>();

            foreach (var accommodation in _accommodationRepository.GetAll())
            {
                if (accommodation.Owner.Id == SignedOwnerId)
                {
                    accommodation.Location = _locationRepository.GetById(accommodation.Location.Id);
                    foreach (var p in _accommodationImagesRepository.GetAll())
                    {
                        if (p.Accomodation.Id == accommodation.Id)
                        {
                            accommodation.Images.Add(p);
                        }
                    }
                    _ownerAccommodations.Add(accommodation);
                }
            }

            return _ownerAccommodations;
        }

    }
}
