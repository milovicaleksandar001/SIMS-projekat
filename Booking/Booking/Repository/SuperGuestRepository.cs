using Booking.Domain.Model;
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
    public class SuperGuestRepository : ISuperGuestRepository
    {
        private const string FilePath = "../../Resources/Data/superGuest.csv";

        private readonly Serializer<SuperGuest> _serializer;

        public List<SuperGuest> _superGuests;

        public SuperGuestRepository()
        {
            _serializer = new Serializer<SuperGuest>();
            _superGuests = _serializer.FromCSV(FilePath);
        }

        public List<SuperGuest> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public SuperGuest GetSuperBySignedGuestId(int id)
        {
            foreach(var sg in _superGuests)
            {
                if(sg.Guest.Id == id)
                {
                    return sg;
                }
            }
            return null;
        }


        public int NextId()
        {
            if (_superGuests.Count == 0)
            {
                return 1;
            }
            else
            {
                return _superGuests.Max(t => t.Id) + 1;
            }
        }
        public void Add(SuperGuest guest)
        {
            guest.Id = NextId();
            _superGuests.Add(guest);
            _serializer.ToCSV(FilePath, _superGuests);
        }

        public void Delete(SuperGuest guest)
        {
            List<SuperGuest> _superGuestCopy = new List<SuperGuest>(_superGuests);

            _superGuests.Clear();
            foreach (var g in _superGuestCopy)
            {
                if (g.Id != guest.Id)
                {
                    _superGuests.Add(guest);
                }
            }
            _serializer.ToCSV(FilePath, _superGuests);
        }

        public void Update(SuperGuest updateGuest)
        {
            int index = _superGuests.FindIndex(u => u.Id == updateGuest.Id);
            _superGuests[index] = updateGuest;
            _serializer.ToCSV(FilePath, _superGuests);
        }

        public SuperGuest GetById(int id)
        {
            throw new NotImplementedException(); //ne treba za sad 
        }
    }
}
