using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Repository
{
	public class LocationRepository : ILocationRepository
	{
		private const string FilePath = "../../Resources/Data/locations.csv";

		private readonly Serializer<Location> _serializer;

		private List<Location> _locations;

		public LocationRepository()
		{
			_serializer = new Serializer<Location>();
			_locations = _serializer.FromCSV(FilePath);
		}

		public List<Location> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}

		public Location GetById(int id)
		{
			return _locations.Find(l => l.Id == id);
		}
	}
}
