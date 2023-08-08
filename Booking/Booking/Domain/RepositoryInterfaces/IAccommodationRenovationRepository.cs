using Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface IAccommodationRenovationRepository : IRepository<AccommodationRenovation>
    {
        int NextId();
        void Add(AccommodationRenovation renovation);
        void Delete(AccommodationRenovation selectedRenovation);
        void Save(List<AccommodationRenovation> list);
    }
}
