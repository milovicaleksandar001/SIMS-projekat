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
    public class ForumRepository : IForumRepository
    {
        private const string FilePath = "../../Resources/Data/forums.csv";

        private readonly Serializer<Forum> _serializer;

        public List<Forum> _forums;

        public ForumRepository()
        {
            _serializer = new Serializer<Forum>();
            _forums = _serializer.FromCSV(FilePath);
        }
        public List<Forum> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
        public Forum GetById(int id)
        {
            return _forums.Find(a => a.Id == id);
        }
        public int NextId()
        {
            if (_forums.Count == 0)
            {
                return 1;
            }
            else
            {
                return _forums.Max(t => t.Id) + 1;
            }
        }
        public Forum Add(Forum forum)
        {
            forum.Id = NextId();
            _forums.Add(forum);
            _serializer.ToCSV(FilePath, _forums);
            return forum;
        }

        public void Update(Forum forum)
        {
            /* List<Forum> forumsCopy = new List<Forum>();
             foreach(var f in _forums)
             {
                 if(f.Id == forum.Id)
                 {
                     forumsCopy.Add(forum);
                 }
                 else
                 {
                     forumsCopy.Add(f);
                 }
             }
             _serializer.ToCSV(FilePath, forumsCopy);*/
            int index = _forums.FindIndex(f => f.Id == forum.Id);
            if (index != -1)
            {
                _forums[index] = forum;
                _serializer.ToCSV(FilePath, _forums);
            }
        }
    }
}
