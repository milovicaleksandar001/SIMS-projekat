using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System.Collections.Generic;

namespace Booking.Repository
{
	public class TourGuestsRepository : ITourGuestsRepository
	{
		private const string FilePath = "../../Resources/Data/tourGuests.csv";

		private readonly Serializer<TourGuests> _serializer;

		public List<TourGuests> _tourGuests;

		public TourGuestsRepository()
		{
			_serializer = new Serializer<TourGuests>();
			_tourGuests = _serializer.FromCSV(FilePath);
		}

		public List<TourGuests> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}
		public TourGuests GetById(int id)
		{
			return null;
		}

		public TourGuests Add(TourGuests tourGuest)
		{
			_tourGuests = _serializer.FromCSV(FilePath);
			_tourGuests.Add(tourGuest);
			_serializer.ToCSV(FilePath, _tourGuests);
			return tourGuest;
		}

		public void DeleteByTourId(int id)
		{
			_tourGuests.RemoveAll(TourKeyPoint => TourKeyPoint.Tour.Id == id);
			_serializer.ToCSV(FilePath, _tourGuests);
		}

		public TourGuests Update(TourGuests tourGuests)
		{
			List<TourGuests> foundedList = _tourGuests.FindAll(t => t.Tour.Id == tourGuests.Tour.Id);
			TourGuests founded = foundedList.Find(t => t.User.Id == tourGuests.User.Id);
			founded = tourGuests;
			_serializer.ToCSV(FilePath, _tourGuests);
			return tourGuests;
		}

		public List<TourGuests> GetByUserId(int id)
		{
			return _tourGuests.FindAll(t => t.User.Id == id);
		}
	}
}
