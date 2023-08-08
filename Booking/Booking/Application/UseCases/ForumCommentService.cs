using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Repository;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.UseCases
{
    public class ForumCommentService : ISubject, IForumCommentService
    {
        private readonly IForumRepository _forumRepository;
        private readonly IForumCommentRepository _forumCommentRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;
        private readonly List<IObserver> _observers;

		public ForumCommentService()
		{
			_forumCommentRepository = InjectorRepository.CreateInstance<IForumCommentRepository>();
            _forumRepository = InjectorRepository.CreateInstance<IForumRepository>();
            _locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
            _observers = new List<IObserver>();
		}

		public List<ForumComment> GetAll()
		{
			List<ForumComment> list = new List<ForumComment>();
			list = _forumCommentRepository.GetAll();
			foreach(var c in list)
			{
				c.Forum = _forumRepository.GetById(c.Forum.Id);
				c.Forum.Location = _locationRepository.GetById(c.Forum.Location.Id); 
				c.User = _userRepository.GetById(c.User.Id);
			}
            return list;
		}
		public void UpdateForumComment(ForumComment forumComment)
		{
			_forumCommentRepository.Update(forumComment);
			NotifyObservers();
		}

		public List<ForumComment> GetForumComments(Forum selectedForum)
		{
            List<ForumComment> list = new List<ForumComment>();
            foreach (var c in _forumCommentRepository.GetAll())
            {
                c.Forum = _forumRepository.GetById(c.Forum.Id);
                c.Forum.Location = _locationRepository.GetById(c.Forum.Location.Id);
                c.User = _userRepository.GetById(c.User.Id);

				if(selectedForum.Location.State.Equals(c.Forum.Location.State) && selectedForum.Location.City.Equals(c.Forum.Location.City))
				{
					list.Add(c);
				}
            }
            return list;
        }
		public ForumComment Create(ForumComment forumComment)
		{
			ForumComment newForumComment = _forumCommentRepository.Add(forumComment);
			NotifyObservers();
            return newForumComment;
		}

		public ForumComment GetById(int id)
		{
			return _forumCommentRepository.GetById(id);
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Add(observer);
		}
		public void Unsubscribe(IObserver observer)
		{
			_observers.Remove(observer);
		}
		public void NotifyObservers()
		{
			foreach (var observer in _observers)
			{
				observer.Update();
			}
		}
	}
}
