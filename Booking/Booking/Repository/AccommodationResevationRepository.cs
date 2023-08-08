using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class AccommodationResevationRepository : IAccommodationResevationRepository
    {
        private const string FilePath = "../../Resources/Data/accommodationsReservations.csv";

        private readonly Serializer<AccommodationReservation> _serializer;

        public List<AccommodationReservation> _reservations;

        public AccommodationResevationRepository()
        {
            _serializer = new Serializer<AccommodationReservation>();
            _reservations = _serializer.FromCSV(FilePath);
		}
        public void Save(List<AccommodationReservation> list)
        {
            _reservations = list;
            _serializer.ToCSV(FilePath, _reservations);
        }

        public List<AccommodationReservation> GetAllWithDeleted()
        {
            return _serializer.FromCSV(FilePath);
        }
        public List<AccommodationReservation> GetAll()
        {
            List<AccommodationReservation> reservations = new List<AccommodationReservation>();
            foreach (AccommodationReservation ar in _serializer.FromCSV(FilePath)) 
            {
                if (ar.Deleted != 1)
                {
                    reservations.Add(ar);
                }
            }
            return reservations;
        }

		public AccommodationReservation GetById(int id)
		{
			return _reservations.Find(a => a.Id == id);
		}
        public int NextId()
        {
            if (_reservations.Count == 0) return 0;
            return _reservations.Max(s => s.Id) + 1;
        }
        public void Add(AccommodationReservation reservation)
        {
            reservation.Id = NextId();
            _reservations.Add(reservation);
            _serializer.ToCSV(FilePath, _reservations);
        }
        public void Delete(AccommodationReservation selectedReservation)
        {
            // _accommodations.Remove(selectedReservation);
            // _accommodations.RemoveAll(r => r.Equals(selectedReservation));
            List<AccommodationReservation> _reservationsCopy = new List<AccommodationReservation>(_reservations);
            
            _reservations.Clear();
           foreach(var reservation in _reservationsCopy)
           {
                if (reservation.Id != selectedReservation.Id)
                {
                    _reservations.Add(reservation);
                }
                else 
                {
                    reservation.Deleted = 1;
                    _reservations.Add(reservation);
                }
           }
            _serializer.ToCSV(FilePath, _reservations);
        }
    }
}
