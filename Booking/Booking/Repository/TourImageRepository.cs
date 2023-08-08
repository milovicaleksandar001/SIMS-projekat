using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Booking.Repository
{
    public class TourImageRepository : ITourImageRepository
    {
        private const string FilePath = "../../Resources/Data/tourImages.csv";

        private readonly Serializer<TourImage> _serializer;

        public List<TourImage> _tourImages;

        public TourImageRepository()
        {
            _serializer = new Serializer<TourImage>();
            _tourImages = _serializer.FromCSV(FilePath);
		}

        public List<TourImage> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public TourImage GetById(int id)
		{
			return _tourImages.Find(t => t.Id == id);
		}

		public int NextId()
		{
			if (_tourImages.Count == 0)
			{
				return 1;
			}
			else
			{
				return _tourImages.Max(t => t.Id) + 1;
			}
		}

		public TourImage Add(TourImage tourImage)
		{
			tourImage.Id = NextId();
			_tourImages.Add(tourImage);
			_serializer.ToCSV(FilePath, _tourImages);
			return tourImage;
		}

		public List<TourImage> GetTourImagesByTourId(int id)
		{
                List<TourImage> list = new List<TourImage>();
                foreach (TourImage image in _tourImages)
                {
                    if (image.Tour.Id == id)
                    {
                        list.Add(image);
                    }
                }
                return list;
		}



        public void DeleteByTourId(int id)
		{
			_tourImages.RemoveAll(TourKeyPoint => TourKeyPoint.Tour.Id == id);
			_serializer.ToCSV(FilePath, _tourImages);
        }

		public TourImage GetByUrl(string url)
		{
			return _tourImages.Find(p => p.Url == url);
		}

        public void Delete(TourImage tourImage)
        {
            TourImage founded = _tourImages.Find(t => t.Id == tourImage.Id);
            _tourImages.Remove(founded);
            _serializer.ToCSV(FilePath, _tourImages);
        }

    }
}
