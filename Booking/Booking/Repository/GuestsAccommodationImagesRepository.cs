using Booking.Domain.Model.Images;
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
    public class GuestsAccommodationImagesRepository : IGuestsAccommodationImagesRepository
    {
        private const string FilePath = "../../Resources/Data/guestsAccommodationImages.csv";

        private readonly Serializer<GuestsAccommodationImages> _serializer;

        public List<GuestsAccommodationImages> _accommodationsImages;

        public GuestsAccommodationImagesRepository()
        {
            _serializer = new Serializer<GuestsAccommodationImages>();
            _accommodationsImages = _serializer.FromCSV(FilePath);
		}

        public List<GuestsAccommodationImages> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public GuestsAccommodationImages GetById(int id)
		{
			return _accommodationsImages.Find(a => a.Id == id);
		}
        public int NextId()
        {
            int maxId = 0;
            foreach (GuestsAccommodationImages image in _accommodationsImages)
            {
                if (image.Id > maxId)
                {
                    maxId = image.Id;
                }
            }
            return maxId + 1;
        }
        public void Add(GuestsAccommodationImages image)
        {
            image.Id = NextId();
            _accommodationsImages.Add(image);
            _serializer.ToCSV(FilePath, _accommodationsImages);
        }
    }
}
