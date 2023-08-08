using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private const string FilePath = "../../Resources/Data/accommodations.csv";

        private readonly Serializer<Accommodation> _serializer;

        public List<Accommodation> _accommodations;

        public AccommodationRepository()
        {
            _serializer = new Serializer<Accommodation>();
            _accommodations = _serializer.FromCSV(FilePath);
		}

        public List<Accommodation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public Accommodation GetById(int id)
		{
			return _accommodations.Find(a => a.Id == id);
		}
        public int NextId()
        {
            if (_accommodations.Count == 0)
            {
                return 1;
            }
            else
            {
                return _accommodations.Max(t => t.Id) + 1;
            }
        }
        public Accommodation Add(Accommodation accommodation)
        {
            accommodation.Id = NextId();
            _accommodations.Add(accommodation);
            _serializer.ToCSV(FilePath, _accommodations);
            return accommodation;
        }
    }
}
