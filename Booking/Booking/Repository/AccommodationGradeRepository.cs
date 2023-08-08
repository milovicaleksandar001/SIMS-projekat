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
    public class AccommodationGradeRepository : IAccommodationGradeRepository
    {
        private const string FilePath = "../../Resources/Data/accommodationGrades.csv";

        private readonly Serializer<AccommodationGrade> _serializer;

        public List<AccommodationGrade> _accommodationsGrades;

        public AccommodationGradeRepository()
        {
            _serializer = new Serializer<AccommodationGrade>();
            _accommodationsGrades = _serializer.FromCSV(FilePath);
		}

        public List<AccommodationGrade> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public AccommodationGrade GetById(int id)
		{
			return _accommodationsGrades.Find(a => a.Id == id);
		}
        public int NextId()
        {
            if (_accommodationsGrades.Count == 0)
            {
                return 1;
            }
            else
            {
                return _accommodationsGrades.Max(t => t.Id) + 1;
            }
        }
        public AccommodationGrade Add(AccommodationGrade accommodationGrade)
        {
            accommodationGrade.Id = NextId();
            _accommodationsGrades.Add(accommodationGrade);
            _serializer.ToCSV(FilePath, _accommodationsGrades);
            return accommodationGrade;
        }
        public bool IsReservationGraded(int accommodationReservationId)
        {
            foreach (var grade in _accommodationsGrades)
            {
                if (grade.Accommodation.Id == accommodationReservationId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
