using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class ForumCommentRepository : IForumCommentRepository
    {
        private const string FilePath = "../../Resources/Data/forumComments.csv";

        private readonly Serializer<ForumComment> _serializer;

        public List<ForumComment> _forumComments;

        public ForumCommentRepository()
        {
            _serializer = new Serializer<ForumComment>();
            _forumComments = _serializer.FromCSV(FilePath);
        }
        public List<ForumComment> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public ForumComment GetById(int id)
        {
            return _forumComments.Find(a => a.Id == id);
        }
        public int NextId()
        {
            if (_forumComments.Count == 0)
            {
                return 1;
            }
            else
            {
                return _forumComments.Max(t => t.Id) + 1;
            }
        }
        public ForumComment Add(ForumComment forumComment)
        {
            forumComment.Id = NextId();
            _forumComments.Add(forumComment);
            _serializer.ToCSV(FilePath, _forumComments);
            return forumComment;
        }
        public void Update(ForumComment forumComment)
        {
            int index = _forumComments.FindIndex(f => f.Id == forumComment.Id);
            if (index != -1)
            {
                _forumComments[index] = forumComment;
                _serializer.ToCSV(FilePath, _forumComments);
            }
        }
    }
}
