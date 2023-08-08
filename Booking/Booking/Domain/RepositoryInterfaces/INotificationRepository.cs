using Booking.Domain.Model;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        int NextId();
        void Add(Notification notification);    
        void SaveChanges(Notification notification);
    }
}
