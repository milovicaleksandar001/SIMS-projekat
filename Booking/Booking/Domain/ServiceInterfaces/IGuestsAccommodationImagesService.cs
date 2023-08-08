using Booking.Domain.Model.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IGuestsAccommodationImagesService : IService<GuestsAccommodationImages>
    {
        void Create(GuestsAccommodationImages image);
    }
}
