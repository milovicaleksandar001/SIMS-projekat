using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Booking.Repository
{
	public class TourRepository : ITourRepository
	{
		private const string FilePath = "../../Resources/Data/tours.csv";

		private readonly Serializer<Tour> _serializer;

		private List<Tour> _tours;

		public TourRepository()
		{
			_serializer = new Serializer<Tour>();
			_tours = _serializer.FromCSV(FilePath);
		}

		public List<Tour> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}

		public Tour GetById(int id)
		{
			return _tours.Find(t => t.Id == id);
		}

		public int NextId()
		{
			if (_tours.Count == 0)
			{
				return 1;
			}
			else
			{
				return _tours.Max(t => t.Id) + 1;
			}
		}

		public Tour Add(Tour tour)
		{
			tour.Id = NextId();
			_tours.Add(tour);
			_serializer.ToCSV(FilePath, _tours);
			return tour;
		}

		public void Delete(Tour tour)
		{
			Tour founded = _tours.Find(t => t.Id == tour.Id);
			_tours.Remove(founded);
			_serializer.ToCSV(FilePath, _tours);
		}

		public Tour GetByName(string name)
		{
			return _tours.Find(t => t.Name == name);
		}

		public Tour GetStartedTour()
		{
			Tour pomtour = new Tour();
			foreach(Tour tour in _tours)
			{
				if(tour.IsStarted)
					pomtour = tour;
			}
			return pomtour;
		}

		public Tour Update(Tour tour)
		{
			Tour founded = _tours.Find(t => t.Id == tour.Id);
			founded = tour;
			_serializer.ToCSV(FilePath, _tours);
			return founded;
		}

		public List<Tour> GetValidTours()
		{
			List<Tour> list = new List<Tour>();
			foreach (Tour tour in _tours)
			{
				if (tour.StartTime > DateTime.Now || tour.StartTime.Date == DateTime.Now.Date)
				{
					list.Add(tour);
				}
			}
			return list;
		}

        public List<int> GetAllGuidesId()
        {
            List<int> list = new List<int>();
            foreach (Tour tour in _tours)
            {
				if (tour.GuideId == 3) // treba da bude signed guide id
				{
					list.Add(tour.GuideId);
				}
				}
            return list;
        }

        public List<Tour> GetToursByGuideAndDateRangeAndLanguage(int guideId, DateTime startDate, DateTime endDate, string language)
        {
            List<Tour> toursByGuideAndDateRangeAndLanguage = new List<Tour>();

            foreach (Tour tour in _tours)
            {
                if (tour.GuideId == guideId && tour.StartTime >= startDate && tour.StartTime <= endDate && tour.Language == language)
                {
                    toursByGuideAndDateRangeAndLanguage.Add(tour);
                }
            }

            return toursByGuideAndDateRangeAndLanguage;
        }

    }
}
