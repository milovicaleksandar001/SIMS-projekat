using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Repository
{
	public class TourReservationRepository : ITourReservationRepository
	{
		private const string FilePath = "../../Resources/Data/tourReservations.csv";

		private readonly Serializer<TourReservation> _serializer;

		private List<TourReservation> _toursReservations;

		public TourReservationRepository()
		{
			_serializer = new Serializer<TourReservation>();
			_toursReservations = _serializer.FromCSV(FilePath);
		}

		public List<TourReservation> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}

		public TourReservation GetById(int id)
		{
			return _toursReservations.Find(t => t.Id == id);
		}

		public int NextId()
		{
			if (_toursReservations.Count == 0)
			{
				return 1;
			}
			else
			{
				return _toursReservations.Max(t => t.Id) + 1;
			}
		}

		public TourReservation Add(TourReservation tourReservation)
		{
			tourReservation.Id = NextId();
			_toursReservations.Add(tourReservation);
			_serializer.ToCSV(FilePath, _toursReservations);
			return tourReservation;
		}

        public void DeleteByTourId(int id)
        {
            _toursReservations.RemoveAll(tr => tr.Tour.Id == id);
            _serializer.ToCSV(FilePath, _toursReservations);
        }

		public List<TourReservation> GetReservationsByGuestId(int id)
		{
			return _toursReservations.FindAll(r => r.User.Id == id);
		}
    }
}
