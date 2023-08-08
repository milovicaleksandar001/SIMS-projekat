using Booking.Domain.DTO;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Booking.Service
{
	public class LocationService : ISubject, ILocationService
	{
		private readonly ILocationRepository _locationRepository;
		private readonly List<IObserver> _observers;
		private IAccommodationResevationRepository _accommodationReservationRepository;
		private IAccommodationRepository _accommodationRepository;
		private IUserRepository _userRepository;

		public LocationService()
		{
			_locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
			_observers = new List<IObserver>();
			_accommodationReservationRepository = InjectorRepository.CreateInstance<IAccommodationResevationRepository>();
			_accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
			_userRepository = InjectorRepository.CreateInstance<IUserRepository>();
		}

		public List<string> GetAllStates()
		{
			List<string> states = new List<string>() { "All" };
			foreach (Location location in _locationRepository.GetAll())
			{
				if (!states.Contains(location.State))
					states.Add(location.State);
			}
			return states;
		}
		public List<Suggestion> GetLocationsForSuggestions() 
		{
			List<Location> locations = new List<Location>();
			List<Suggestion> suggestions = new List<Suggestion>();
			locations = GetOwnerLocations();
			foreach (var location in locations) 
			{
				Suggestion suggestion = new Suggestion();
				suggestion.Id = location.Id;
				suggestion.City = location.City;
				suggestion.State = location.State;
				suggestion.Reservations = 0;
				suggestions.Add(suggestion);
			}
			foreach (var r in _accommodationReservationRepository.GetAll()) 
			{
				r.Accommodation = _accommodationRepository.GetById(r.Accommodation.Id);
				r.Accommodation.Location = _locationRepository.GetById(r.Accommodation.Location.Id);
				if (r.Accommodation.Owner.Id == AccommodationService.SignedOwnerId) 
				{
					foreach (var suggestion in suggestions) 
					{
						if (suggestion.Id == r.Accommodation.Location.Id) 
						{
							suggestion.Reservations++;
						}
					}
				}
			}
			return suggestions;
		}

		public List<Suggestion> GetBestLocations() 
		{
			List<Suggestion> suggestions = new List<Suggestion>();
			suggestions = GetLocationsForSuggestions();
			Suggestion bestSuggestion = new Suggestion();
			Suggestion bestSuggestion2 = new Suggestion();
			List<Suggestion> bestSuggestions = new List<Suggestion>();
			if (suggestions.Count < 2) 
			{
				bestSuggestion.City = "/";
				bestSuggestion.State = "/";
				bestSuggestion2.State = "/";
				bestSuggestion2.City = "/";
				bestSuggestions.Add(bestSuggestion);
				bestSuggestions.Add(bestSuggestion2);
				return bestSuggestions;
			}
			if (suggestions[0].Reservations > suggestions[1].Reservations)
			{
				bestSuggestion = suggestions[0];
				bestSuggestion2 = suggestions[1];
			}
			else 
			{
				bestSuggestion = suggestions[1];
				bestSuggestion2 = suggestions[0];
			}
			foreach (var sug in suggestions) 
			{
				if (sug.Id == bestSuggestion.Id || sug.Id == bestSuggestion2.Id) 
				{
					continue;
				}
				if (sug.Reservations > bestSuggestion.Reservations)
				{
					bestSuggestion2 = bestSuggestion;
					bestSuggestion = sug;
				}
				else if(sug.Reservations>bestSuggestion2.Reservations)
				{
					bestSuggestion2 = sug;
				}
			}
			bestSuggestions.Add(bestSuggestion);
			bestSuggestions.Add(bestSuggestion2);
			return bestSuggestions;
		}
		public bool DoesOwnerHaveLocation(int locationId) 
		{
			foreach (var a in _accommodationRepository.GetAll()) 
			{
				if (a.Owner.Id == AccommodationService.SignedOwnerId && a.Location.Id == locationId) 
				{
					return true;
				}
			}
			return false;
		}
		public List<Suggestion> GetWorstLocations()
		{
			List<Suggestion> suggestions = new List<Suggestion>();
			suggestions = GetLocationsForSuggestions();
			Suggestion worstSuggestion = new Suggestion();
			Suggestion worstSuggestion2 = new Suggestion();
			List<Suggestion> worstSuggestions = new List<Suggestion>();
			if (suggestions.Count < 2) 
			{
				worstSuggestion.City = "/";
				worstSuggestion.State = "/";
				worstSuggestion2.State = "/";
				worstSuggestion2.City = "/";
				worstSuggestions.Add(worstSuggestion);
				worstSuggestions.Add(worstSuggestion2);
				return worstSuggestions;
			}
			if (suggestions[0].Reservations < suggestions[1].Reservations)
			{
				worstSuggestion = suggestions[0];
				worstSuggestion2 = suggestions[1];
			}
			else
			{
				worstSuggestion = suggestions[1];
				worstSuggestion2 = suggestions[0];
			}
			foreach (var sug in suggestions)
			{
				if (sug.Id == worstSuggestion.Id || sug.Id == worstSuggestion2.Id)
				{
					continue;
				}
				if (sug.Reservations < worstSuggestion.Reservations)
				{
					worstSuggestion2 = worstSuggestion;
					worstSuggestion = sug;
				}
				else if (sug.Reservations < worstSuggestion2.Reservations)
				{
					worstSuggestion2 = sug;
				}
			}
			worstSuggestions.Add(worstSuggestion);
			worstSuggestions.Add(worstSuggestion2);
			List<Suggestion> bestSuggestions = new List<Suggestion>();
			bestSuggestions = GetBestLocations();
			foreach (var b in bestSuggestions) 
			{
				foreach (var w in worstSuggestions) 
				{
					if (b.Id == w.Id) 
					{
						w.State = "/";
						w.City = "/";
					}
				}
			}
			return worstSuggestions;
		}

		public List<Location> GetOwnerLocations() 
		{
			List<Location> locations = new List<Location>();
			foreach (var a in _accommodationRepository.GetAll())
			{
				a.Location = _locationRepository.GetById(a.Location.Id);
				if (a.Owner.Id == AccommodationService.SignedOwnerId) 
				{
					int flag = 0;
					foreach (var l in locations) 
					{
						if (a.Location.Id == l.Id) 
						{
							flag = 1;
						}
					}
					if (flag == 0)
					{
						locations.Add(a.Location);
					}
				}
			}
			return locations;
		}

		public ObservableCollection<string> GetAllCitiesByState(ObservableCollection<string> observe, string state)
		{
			observe.Clear();
			observe.Add("All");
			foreach (Location location in _locationRepository.GetAll())
			{
				if (location.State == state)
					observe.Add(location.City);
			}
			return observe;
		}

		public int GetIdByCountryAndCity(string Country, string City)
		{
			foreach (var location in _locationRepository.GetAll())
			{
				if (location.City.Equals(City) && location.State.Equals(Country))
				{
					return location.Id;
				}
			}
			return -1;
		}

		public List<Location> GetAll()
		{
			return _locationRepository.GetAll();
		}

        public Location GetById(int id)
        {
            return _locationRepository.GetById(id);
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
