using Booking.Domain.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IForumCommentService : IService<ForumComment>, ISubject
    {
        List<ForumComment> GetAll();
        ForumComment GetById(int id);
        List<ForumComment> GetForumComments(Forum selectedForum);
        ForumComment Create(ForumComment forumComment);
        void UpdateForumComment(ForumComment forumComment);
    }
}
