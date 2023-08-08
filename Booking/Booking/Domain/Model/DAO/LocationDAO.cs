using Booking.Observer;
using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Model;
using System.Windows;
using System.Security.Cryptography.X509Certificates;

namespace Booking.Model.DAO
{
	public class LocationDAO : ISubject
	{
		private readonly LocationRepository repository;
		private  List<Location> locations;
        private readonly List<IObserver> observers;

        public LocationDAO()
		{
			repository = new LocationRepository();
			locations = repository.Load();
			observers = new List<IObserver>();		
		}

        
        public void Load()
        {
            locations = repository.Load();
        }

        public int GetIdByCountryAndCity(string Country, string City) 
        {
            foreach (var location in locations) 
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
			return locations;
		}

		public Location FindById(int id)
		{
			return locations.Find(v => v.Id == id);
		}

        public Location FindByCountryAndCity( string Name)
        {
            string[] pom = Name.Split(',');
            pom[1] = pom[1].Trim();    
            foreach (Location loc in locations) 
            {
                
                if (loc.City == pom[1])
                { 
                    return loc;
                }
            }

            return null; 
        }

        public int FindIdByCountryAndCity(string Country, string City)
        {
            foreach (var location in locations)
            {
                if (location.City.Equals(City) && location.State.Equals(Country))
                {
                    return location.Id;
                }
            }
            return -1;
        }

        public Location addLocation(Location location) 
		{
		    location.Id = NextId();
			locations.Add(location);
			repository.Save(locations);
			NotifyObservers();
			return location;
		}

        public int NextId()
        {
            if (locations.Count == 0)
            {
                return 1;
            }
            else
            {
                return locations.Max(l => l.Id) + 1;
            }
        }

        public List<Location> FindAllLocations()
        {
            return locations;
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

    

		public List<string> GetAllStates()
		{
			List<string> states = new List<string>() { "All" };
			foreach (Location location in locations) 
			{
				if(!states.Contains(location.State))
					states.Add(location.State);
			}
			return states;
		}

		public ObservableCollection<string> GetAllCitiesByState(ObservableCollection<string> observe, string state) 
		{
			observe.Clear();
			observe.Add("All");
			foreach (Location location in locations) 
			{
				if(location.State == state)
					observe.Add(location.City);
			}
			return observe;
		}
	}
}
