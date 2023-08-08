using Booking.Domain.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IForumService : IService<Forum>, ISubject
    {
        List<Forum> GetAll();
        Forum GetById(int id);
        void Create(Forum forum);
        void UpdateForum(Forum forum);
        void SetVeryHelpful(Forum forum);
    }
}
