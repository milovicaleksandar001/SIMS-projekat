using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Booking.Repository
{
    public class AccommodationImagesRepository : IAccommodationImagesRepository
    {

        private const string FilePath = "../../Resources/Data/accommodationImages.csv";

        private readonly Serializer<AccommodationImage> _serializer;

        public List<AccommodationImage> _accommodationsImages;

        public AccommodationImagesRepository()
        {
            _serializer = new Serializer<AccommodationImage>();
            _accommodationsImages = _serializer.FromCSV(FilePath);
		}

        public List<AccommodationImage> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public AccommodationImage GetById(int id)
		{
			return _accommodationsImages.Find(a => a.Id == id);
		}
        public int NextId()
        {
            int maxId = 0;
            foreach (AccommodationImage image in _accommodationsImages)
            {
                if (image.Id > maxId)
                {
                    maxId = image.Id;
                }
            }
            return maxId + 1;
        }
        public void Add(AccommodationImage image)
        {
            image.Id = NextId();
            _accommodationsImages.Add(image);
            _serializer.ToCSV(FilePath, _accommodationsImages);
        }
    }
}
