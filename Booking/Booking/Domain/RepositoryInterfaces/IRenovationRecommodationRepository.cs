using Booking.Domain.Model;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface IRenovationRecommodationRepository  : IRepository<RenovationRecommodation>
    {
        int NextId();
        void Add(RenovationRecommodation renovationRecommodation);
    }
}
