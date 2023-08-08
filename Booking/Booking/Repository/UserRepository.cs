using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
	public class UserRepository : IUserRepository
	{
		private const string FilePath = "../../Resources/Data/users.csv";

		private readonly Serializer<User> _serializer;

		private List<User> _users;

		public UserRepository()
		{
			_serializer = new Serializer<User>();
			_users = _serializer.FromCSV(FilePath);
		}
        public List<User> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

		public User GetById(int id)
		{
			return _users.Find(u => u.Id == id);
		}

		public User GetByUsername(string username)
		{
			_users = _serializer.FromCSV(FilePath);
			return _users.Find(u => u.Username == username);
		}

        public void Save(List<User> users) // save kao u tourRepository?
        {
            _serializer.ToCSV(FilePath, users);
        }

		public void Update(User updatedUser)
		{
            int index = _users.FindIndex(u => u.Id == updatedUser.Id);
            _users[index] = updatedUser;
            _serializer.ToCSV(FilePath, _users);
        }

        public void UpdateSuper(User updatedUser)
        {
            int index = _users.FindIndex(u => u.Id == updatedUser.Id);
			updatedUser.Super = 1;
            _serializer.ToCSV(FilePath, _users);
        }

		public void Delete(User user)
		{
			User founded = _users.Find(u => u.Id == user.Id);
			_users.Remove(founded);
			_serializer.ToCSV(FilePath, _users);
		}
    }
}
