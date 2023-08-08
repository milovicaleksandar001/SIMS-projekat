using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Repository;
using Booking.Util;
using System.Collections.Generic;

namespace Booking.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ITourReservationRepository _tourReservationRepository;

		private readonly List<IObserver> _observers;

		public UserService()
		{
			_userRepository = InjectorRepository.CreateInstance<IUserRepository>();
			_tourReservationRepository = InjectorRepository.CreateInstance<ITourReservationRepository>();
			_observers = new List<IObserver>();
		}

		public List<User> GetGuests()
		{
			List<User> users = new List<User>();
			foreach (var user in _userRepository.GetAll())
			{
				if (user.Role == 4)
				{
					users.Add(user);
				}
			}
			return users;
		}

        public List<User> GetReservedGuests(int tourId)
        {
            List<User> users = new List<User>();
            foreach(TourReservation tr in _tourReservationRepository.GetAll())
            {
             if(tr.Tour.Id == tourId)
				{
					User pomUser = _userRepository.GetById(tr.User.Id);
					users.Add(pomUser);
				}
            }
            return users;
        }
		public void SaveWizard(User user1) 
		{
			List<User> AllUsers = new List<User>();
			AllUsers = _userRepository.GetAll();
			foreach (var user in AllUsers)
			{
				if (user.Id == user1.Id) 
				{
					user.Wizard = 1;
				}
			}
			_userRepository.Save(AllUsers);
		}


		public User GetByUsername(string username)
		{
			return _userRepository.GetByUsername(username);
		}

		public User removeUser(int idUser)
		{
			User user = _userRepository.GetById(idUser);
			if (user == null) return null;

			_userRepository.Delete(user);
            NotifyObservers();
            return user;
        }

		public void NotifyObservers()
		{
			foreach (var observer in _observers)
			{
				observer.Update();
			}
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Add(observer);
		}

		public void Unsubscribe(IObserver observer)
		{
			_observers.Remove(observer);
		}

		public User GetById(int id)
		{
			return _userRepository.GetById(id);
		}
	}
}
