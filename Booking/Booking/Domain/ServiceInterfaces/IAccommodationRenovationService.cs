using Booking.Domain.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IAccommodationRenovationService : IService<AccommodationRenovation>, ISubject
    {
        AccommodationRenovation GetById(int id);
        void SaveRenovation(AccommodationRenovation renovation);
        List<AccommodationRenovation> GetSeeableRenovations();
        void Delete(AccommodationRenovation selectedRenovation);

    }
}
