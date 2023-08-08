using Booking.Domain.ServiceInterfaces;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Booking.Service
{
    public class AccommodationImageService : IAccommodationImageService
    {

        private readonly AccommodationImagesRepository _repository;

		public AccommodationImageService()
        {
            _repository = new AccommodationImagesRepository();
        }

        public List<AccommodationImage> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(AccommodationImage image)
        {
            _repository.Add(image);
        }

    }
}
