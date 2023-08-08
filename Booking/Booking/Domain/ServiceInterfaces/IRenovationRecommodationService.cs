using Booking.Domain.Model;
using Booking.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IRenovationRecommodationService : IService<RenovationRecommodation>, ISubject
    {
        int NextId();
        void SaveReccommodation(RenovationRecommodation recommodation);
    }
}
