using Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface ISuperGuideRepository : IRepository<SuperGuide>
    {
        SuperGuide GetSuperBySignedGuideId(int id);
        int NextId();
        void Add(SuperGuide guide);
        void Delete(SuperGuide guide);
        void Update(SuperGuide updateGuide);
    }
}
