using Booking.Domain.Model;
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
    public class RenovationRecommodationRepository : IRenovationRecommodationRepository
    {
        private const string FilePath = "../../Resources/Data/renovationRecommodations.csv";

        private readonly Serializer<RenovationRecommodation> _serializer;

        public List<RenovationRecommodation> _renovationRecommodations;

        public RenovationRecommodationRepository()
        {
            _serializer = new Serializer<RenovationRecommodation>();
            _renovationRecommodations = _serializer.FromCSV(FilePath);
        }

        public List<RenovationRecommodation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public RenovationRecommodation GetById(int id)
        {
            return _renovationRecommodations.Find(a => a.Id == id);
        }
        public int NextId()
        {
            if (_renovationRecommodations.Count == 0)
            {
                return 1;
            }
            else
            {
                return _renovationRecommodations.Max(t => t.Id) + 1;
            }
        }

        public void Add(RenovationRecommodation renovationRecommodation)
        {
            renovationRecommodation.Id = NextId();
            _renovationRecommodations.Add(renovationRecommodation);
            _serializer.ToCSV(FilePath, _renovationRecommodations);
        }
    }
}
