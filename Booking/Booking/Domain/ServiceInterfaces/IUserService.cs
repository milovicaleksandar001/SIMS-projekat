using Booking.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IUserService : ISubject, IService<User>
    {
        List<User> GetGuests();
        User GetByUsername(string username);
        List<User> GetReservedGuests(int tourId);
        User GetById(int id);
        User removeUser(int idUser);
        void SaveWizard(User user1);
    }
}
