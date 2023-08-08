using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class AccommodationRenovationRepository : IAccommodationRenovationRepository
    {
        private const string FilePath = "../../Resources/Data/accommodationsRenovations.csv";

        private readonly Serializer<AccommodationRenovation> _serializer;

        public List<AccommodationRenovation> _renovations;

        public AccommodationRenovationRepository()
        {
            _serializer = new Serializer<AccommodationRenovation>();
            _renovations = _serializer.FromCSV(FilePath);
        }
        public void Save(List<AccommodationRenovation> list)
        {
            _renovations = list;
            _serializer.ToCSV(FilePath, _renovations);
        }

        public List<AccommodationRenovation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public AccommodationRenovation GetById(int id)
        {
            return _renovations.Find(a => a.Id == id);
        }
        public int NextId()
        {
            if (_renovations.Count == 0) return 0;
            return _renovations.Max(s => s.Id) + 1;
        }
        public void Add(AccommodationRenovation renovation)
        {
            renovation.Id = NextId();
            _renovations.Add(renovation);
            _serializer.ToCSV(FilePath, _renovations);
        }
        public void Delete(AccommodationRenovation selectedRenovation)
        {
            List<AccommodationRenovation> _renovationsCopy = new List<AccommodationRenovation>(_renovations);

            _renovations.Clear();
            foreach (var renovation in _renovationsCopy)
            {
                if (renovation.Id != selectedRenovation.Id)
                {
                    _renovations.Add(renovation);
                }
            }
            _serializer.ToCSV(FilePath, _renovations);
        }
    }
}
