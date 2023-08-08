using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class TourKeyPointRepository : ITourKeyPointRepository
    {
        private const string FilePath = "../../Resources/Data/tourKeyPoints.csv";

        private readonly Serializer<TourKeyPoint> _serializer;

        public List<TourKeyPoint> _tourKeyPoints;

        public TourKeyPointRepository()
        {
            _serializer = new Serializer<TourKeyPoint>();
            _tourKeyPoints = _serializer.FromCSV(FilePath);
		}

		public List<TourKeyPoint> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public TourKeyPoint GetById(int id)
		{
			return _tourKeyPoints.Find(t => t.Id == id);
		}

		public int NextId()
		{
			if (_tourKeyPoints.Count == 0)
			{
				return 1;
			}
			else
			{
				return _tourKeyPoints.Max(t => t.Id) + 1;
			}
		}

		public TourKeyPoint Add(TourKeyPoint keyPoint)
		{
			keyPoint.Id = NextId();
			_tourKeyPoints.Add(keyPoint);
			_serializer.ToCSV(FilePath, _tourKeyPoints);
			return keyPoint;
		}

		public TourKeyPoint Update(TourKeyPoint keyPoint)
		{
			TourKeyPoint founded = _tourKeyPoints.Find(t => t.Id == keyPoint.Id);
			founded = keyPoint;
			_serializer.ToCSV(FilePath, _tourKeyPoints);
			return founded;
		}

		public List<TourKeyPoint> GetKeyPointsByTourId(int id)
		{
			List<TourKeyPoint> list = new List<TourKeyPoint>();
			foreach (TourKeyPoint keyPoint in _tourKeyPoints)
			{
				if (keyPoint.Tour.Id == id)
				{
					list.Add(keyPoint);
				}
			}
			return list;
		}

		public void DeleteByTourId(int id)
		{
			_tourKeyPoints.RemoveAll(TourKeyPoint => TourKeyPoint.Tour.Id == id);
			_serializer.ToCSV(FilePath, _tourKeyPoints);
		}

        public void DeleteById(int id)
        {
            _tourKeyPoints.RemoveAll(tourKeyPoint => tourKeyPoint.Id == id);
            _serializer.ToCSV(FilePath, _tourKeyPoints);
        }
    }
}
