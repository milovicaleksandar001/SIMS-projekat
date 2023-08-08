using Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.RepositoryInterfaces
{
    public interface IForumCommentRepository : IRepository<ForumComment>
    {
        int NextId();
        ForumComment Add(ForumComment forumComment);
        void Update(ForumComment forumComment);
    }
}
