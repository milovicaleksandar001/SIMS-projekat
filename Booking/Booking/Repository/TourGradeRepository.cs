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
    public class TourGradeRepository : ITourGradeRepository
    {
        private const string FilePath = "../../Resources/Data/tourGrades.csv";
        private readonly Serializer<TourGrade> _serializer;
        private List<TourGrade> _tourGrades;

        public TourGradeRepository()
        {
            _serializer = new Serializer<TourGrade>();
            _tourGrades =_serializer.FromCSV(FilePath);
        }
        public List<TourGrade> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public TourGrade GetById(int id)
        {
           return _tourGrades.Find(tg => tg.Id == id);
        }

        public TourGrade Update(TourGrade tourGrade) 
        {
            TourGrade founded = _tourGrades.Find(tg=> tg.Id == tourGrade.Id);
            founded = tourGrade;
            _serializer.ToCSV(FilePath, _tourGrades);
            return founded;
        }

        public int NextId()
        {
            if (_tourGrades.Count == 0)
            {
                return 1;
            }
            else
            {
                return _tourGrades.Max(t => t.Id) + 1;
            }
        }

        public TourGrade Add(TourGrade tourGrade)
        {
			tourGrade.Id = NextId();
			_tourGrades.Add(tourGrade);
			_serializer.ToCSV(FilePath, _tourGrades);
			return tourGrade;
		}

        public List<TourGrade> GetAllByGuestId(int id)
        {
            return _tourGrades.FindAll(t => t.Guest.Id == id);
        }

        public TourGrade GetByTourId(int id)
        {
            foreach (TourGrade grade in _tourGrades)
            {
                if (grade.Tour.Id == id)
                {
                    return grade;
                }
            }
            return null;
        }
    }
}
