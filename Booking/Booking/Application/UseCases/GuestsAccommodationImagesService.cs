using Booking.Domain.Model.Images;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model.Images;
using Booking.Repository;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Service
{
    public class GuestsAccommodationImagesService : IGuestsAccommodationImagesService
    {
        private readonly IGuestsAccommodationImagesRepository _repository;

		public GuestsAccommodationImagesService()
        {
            _repository = InjectorRepository.CreateInstance<IGuestsAccommodationImagesRepository>();
        }

        public void Create(GuestsAccommodationImages image)
        {
            _repository.Add(image);
        }

    }
}
