using Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface IForumRepository : IRepository<Forum>
    {
        int NextId();
        Forum Add(Forum forum);
        void Update(Forum forum);  
    }
}
