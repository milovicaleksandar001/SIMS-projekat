using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Repository;

namespace Booking.Model.DAO
{
	public class TourDAO : ISubject
	{
		private readonly List<IObserver> observers;
		private readonly TourRepository repository;
		private List<Tour> tours;
		//--------------------------------------------------------
		private List<TourImage> tourImages;
		private TourImagesRepository _tourImagesRepository;
		//--------------------------------------------------------
		private List<TourKeyPoints> tourKeyPoints;
		private TourKeyPointsRepository _tourKeyPointsRepository;
		//--------------------------------------------------------
		private List<Location> locations;
		private LocationRepository _locationRepository;
		private LocationDAO locationDAO;
		//--------------------------------------------------------


		public TourDAO()
		{
			repository = new TourRepository();
			observers = new List<IObserver>();
			tours = repository.Load();
			locationDAO = new LocationDAO();
			//--------------------------------------------------------
			_tourImagesRepository = new TourImagesRepository();
			tourImages = new List<TourImage>();
			//--------------------------------------------------------
			_tourKeyPointsRepository = new TourKeyPointsRepository();
			tourKeyPoints = new List<TourKeyPoints>();
			//--------------------------------------------------------
			_locationRepository = new LocationRepository();
			locations = new List<Location>();
			//--------------------------------------------------------
			Load();
		}


		public void Load()
		{
			tours = repository.Load();
			tourImages = _tourImagesRepository.Load();
			tourKeyPoints = _tourKeyPointsRepository.Load();
			locations = _locationRepository.Load();
			AppendLocations();
			AppendLocationsForKeyPoints();
		}



		public void AppendLocations()
		{
			locationDAO.Load();

			foreach (Tour tour in tours)
			{
				tour.Location = locationDAO.FindById(tour.Location.Id);
			}
		}

		public void AppendLocationsForKeyPoints()
		{
			locationDAO.Load();

			foreach (TourKeyPoints keypoint in tourKeyPoints)
			{
				keypoint.Location = locationDAO.FindById(keypoint.Location.Id);
			}
		}

		public List<Tour> GetAll()
		{
			return tours;
		}

		public List<Tour> GetTodayTours()
		{
			List<Tour> list = new List<Tour>();
			foreach (var tour in tours)
			{
				if (tour.StartTime == DateTime.Today)
				{
					list.Add(tour);
				}
			}
			return list;
		}


		public Tour FindById(int id)
		{
			return tours.Find(v => v.Id == id);
		}

		public TourKeyPoints findKeyPointById(int id)
		{
			return tourKeyPoints.Find(t => t.Id == id);
		}


		public void Search(ObservableCollection<Tour> observe, string state, string city, string duration, string language, string passengers)
		{
			observe.Clear();

			foreach (Tour tour in tours)
			{
				if ((tour.Location.State.Equals(state) || state.Equals("All")) && (tour.Location.City.Equals(city) || city.Equals("All")) && (tour.Language.ToLower().Contains(language.ToLower()) || language.Equals("")))
				{
					if (duration.Equals("") && passengers.Equals(""))
					{
						observe.Add(tour);
					}
					else if (duration.Equals("") && !passengers.Equals(""))
					{
						if (tour.MaxVisitors >= Convert.ToInt32(passengers))
						{
							observe.Add(tour);
						}
					}
					else if (!duration.Equals("") && passengers.Equals(""))
					{
						if (tour.Duration == Convert.ToDouble(duration))
						{
							observe.Add(tour);
						}
					}
					else
					{
						if (tour.MaxVisitors >= Convert.ToInt32(passengers) && tour.Duration == Convert.ToDouble(duration))
						{
							observe.Add(tour);
						}
					}
				}
			}
		}

		public void CancelSearch(ObservableCollection<Tour> observe)
		{
			observe.Clear();

			foreach (Tour tour in tours)
			{
				observe.Add(tour);
			}
		}


		public List<string> GetAllStates()
		{
			return locationDAO.GetAllStates();
		}

		public ObservableCollection<string> GetAllCitiesByState(ObservableCollection<string> observe, string state)
		{
			return locationDAO.GetAllCitiesByState(observe, state);
		}


		public Tour UpdateTour(Tour tour)
		{
			Tour oldTour = FindById(tour.Id);
			if (oldTour == null) return null;

			oldTour.Name = tour.Name;
			oldTour.Location.Id = tour.Location.Id;
			oldTour.Description = tour.Description;
			oldTour.Language = tour.Language;
			oldTour.MaxVisitors = tour.MaxVisitors;
			oldTour.StartTime = tour.StartTime;
			oldTour.Duration = tour.Duration;
			oldTour.IsStarted = tour.IsStarted;

			repository.Save(tours);
			NotifyObservers();

			return oldTour;
		}

		public TourKeyPoints UpdateKeyPoint(TourKeyPoints tourKeyPoint)
		{
			TourKeyPoints oldTourKeyPoint = findKeyPointById(tourKeyPoint.Id);

			oldTourKeyPoint.Tour = tourKeyPoint.Tour;
			oldTourKeyPoint.Location = tourKeyPoint.Location;
			oldTourKeyPoint.Achieved = tourKeyPoint.Achieved;

			_tourKeyPointsRepository.Save(tourKeyPoints);
			NotifyObservers();

			return oldTourKeyPoint;
		}

		public void NotifyObservers()
		{
			foreach (var observer in observers)
			{
				observer.Update();
			}
		}

		public void Subscribe(IObserver observer)
		{
			observers.Add(observer);
		}

		public void Unsubscribe(IObserver observer)
		{
			observers.Remove(observer);
		}

		public int NextId()
		{
			if (tours.Count == 0)
			{
				return 1;
			}
			else
			{
				return tours.Max(t => t.Id) + 1;
			}
		}

		public int ImageNextId()
		{
			if (tourImages.Count == 0)
			{
				return 1;
			}
			else
			{
				return tourImages.Max(t => t.Id) + 1;
			}
		}

		public int KeyPointsNextId()
		{
			if (tourKeyPoints.Count == 0)
			{
				return 1;
			}
			else
			{
				return tourKeyPoints.Max(t => t.Id) + 1;
			}
		}

		public List<TourKeyPoints> getSelectedTourKeyPoints(int idTour)
		{
			List<TourKeyPoints> lista = new List<TourKeyPoints>();

			foreach(var keypoint in tourKeyPoints)
			{
					if (keypoint.Tour.Id == idTour )
					{
					/*if(lista.Count < 1)
					{
						keypoint.Achieved = true;
						
					}*/
						lista.Add(keypoint);
					}			
			}

			return lista;
		}

    

		public List<TourKeyPoints> getAllKeyPoints()
		{
            List<TourKeyPoints> lista = new List<TourKeyPoints>();

			foreach(var keypoint in tourKeyPoints)
			{
				lista.Add(keypoint);
			}
			return lista;
        }

        public Tour addTour(Tour tour)
		{
			tour.Id = NextId();
			foreach(var destination in tour.Destinations)
			{
				destination.Id = KeyPointsNextId();
				destination.Tour = tour;
				tourKeyPoints.Add(destination);
			}

			foreach (var picture in tour.Images)
			{
				picture.Id = ImageNextId();
				picture.Tour = tour;
				tourImages.Add(picture);
			}
			tours.Add(tour);
			repository.Save(tours);
			_tourImagesRepository.Save(tourImages);
			_tourKeyPointsRepository.Save(tourKeyPoints);

			NotifyObservers();
			return tour;
		}

	}
}
