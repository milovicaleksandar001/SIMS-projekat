using Booking.Domain.Model;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface ISuperGuestRepository : IRepository<SuperGuest>
    {
        int NextId();
        void Add(SuperGuest guest);
        void Delete(SuperGuest guest);
        void Update(SuperGuest updateGuest);
        SuperGuest GetSuperBySignedGuestId(int id);
    }
}
