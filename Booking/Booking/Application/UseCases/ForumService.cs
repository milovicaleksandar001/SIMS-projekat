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
    public class ForumService : ISubject, IForumService
	{
		private readonly IForumRepository _forumRepository;
		private readonly IForumCommentRepository _forumCommentRepository;
		private readonly ILocationRepository _locationRepository;
		private readonly IUserRepository _userRepository;
		private readonly IAccommodationRepository _accommodationRepository;
		private readonly INotificationRepository _notificationRepository;
		private readonly List<IObserver> _observers;

		public ForumService()
		{
			_forumRepository = InjectorRepository.CreateInstance<IForumRepository>();
            _forumCommentRepository = InjectorRepository.CreateInstance<IForumCommentRepository>();
			_locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
			_userRepository = InjectorRepository.CreateInstance<IUserRepository>();
			_accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
			_notificationRepository = InjectorRepository.CreateInstance<INotificationRepository>();
			_observers = new List<IObserver>();
		}

		public List<Forum> GetAll()
		{
			List<Forum> list = new List<Forum>();
			list = _forumRepository.GetAll();
			foreach (var f in list)
			{ 
				f.Location = _locationRepository.GetById(f.Location.Id);
				f.User = _userRepository.GetById(f.User.Id);
			}
			list = CheckVeryHelpful(list);
			return list;
		}
		public List<Forum> CheckVeryHelpful(List<Forum> list) 
		{
			foreach (var f in list) 
			{
				int ownerComments = 0;
				int guestComments = 0;
				foreach (var com in _forumCommentRepository.GetAll()) 
				{
					com.User = _userRepository.GetById(com.User.Id);
					if (com.Forum.Id == f.Id && com.User.Role == 1)
					{
						ownerComments++;
					}
					else if (com.Forum.Id == f.Id && com.User.Role == 3 && com.Visited.Equals("YES")) 
					{
						guestComments++;
					}
				}
				if (ownerComments >= 10 && guestComments >= 20) 
				{
					f.Helpful = "YES";
				}
			}
			return list;
		}

		public void SetVeryHelpful(Forum forum)
		{
			bool isVeryHelpful = false;
            int ownerComments = 0;
            int guestComments = 0;
            foreach (var com in _forumCommentRepository.GetAll())
			{ 
                com.User = _userRepository.GetById(com.User.Id);
                if (com.Forum.Id == forum.Id && com.User.Role == 1) //vlasnik ima smestaj na toj lokaciji
                {
                    ownerComments++;
                }
                else if (com.Forum.Id == forum.Id && com.User.Role == 3 && com.Visited.Equals("YES")) //gost mora da je posetio lokaciju
                {
                    guestComments++;
                }
            }
            if (ownerComments >= 10 && guestComments >= 20)
            {
				isVeryHelpful = true;
                forum.Helpful = "YES";
            }
			if (isVeryHelpful)
			{
                UpdateForum(forum);
            }
        }

		public Forum GetById(int id)
		{
			return _forumRepository.GetById(id);
		}

		public void Create(Forum forum)
		{
			Forum newForum = _forumRepository.Add(forum);

			foreach(var comment in newForum.Comments)
			{
				comment.Forum = newForum;
				comment.User.Id = newForum.User.Id;
				comment.Reports = 0;
				_forumCommentRepository.Add(comment);
            }
			List<int> Ids = new List<int>();
			foreach (var a in _accommodationRepository.GetAll()) 
			{
				if (a.Location.Id == newForum.Location.Id) 
				{
					Ids.Add(a.Owner.Id);
				}
			}
			Ids = Ids.Distinct().ToList();
			foreach (var id in Ids) 
			{
				Notification notification = new Notification();
				notification.User.Id = id;
				notification.Message = "A new forum has been opened for location "+ newForum.Location.State+"/" +newForum.Location.City;
				notification.IsRead = false;
				notification.Title = "titleOwner";
				_notificationRepository.Add(notification);
			}
		}

		public void UpdateForum(Forum forum)
		{
			_forumRepository.Update(forum);
			NotifyObservers();
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
