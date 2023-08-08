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
    public class AccommodationAndOwnerGradeRepository : IAccommodationAndOwnerGradeRepository
    {
        private const string FilePath = "../../Resources/Data/accommodationAndOwnerGrade.csv";

        private readonly Serializer<AccommodationAndOwnerGrade> _serializer;

        public List<AccommodationAndOwnerGrade> _accommodationsAndOwnerGrades;

        public AccommodationAndOwnerGradeRepository()
        {
            _serializer = new Serializer<AccommodationAndOwnerGrade>();
            _accommodationsAndOwnerGrades = _serializer.FromCSV(FilePath);
		}

        public List<AccommodationAndOwnerGrade> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public AccommodationAndOwnerGrade GetById(int id)
		{
			return _accommodationsAndOwnerGrades.Find(a => a.Id == id);
		}
        public int NextId()
        {
            if (_accommodationsAndOwnerGrades.Count == 0)
            {
                return 1;
            }
            else
            {
                return _accommodationsAndOwnerGrades.Max(t => t.Id) + 1;
            }
        }
        public void Add(AccommodationAndOwnerGrade grade)
        {
            //grade.Id = NextId(); 
            _accommodationsAndOwnerGrades.Add(grade);
            _serializer.ToCSV(FilePath, _accommodationsAndOwnerGrades);
        }
    }
}
