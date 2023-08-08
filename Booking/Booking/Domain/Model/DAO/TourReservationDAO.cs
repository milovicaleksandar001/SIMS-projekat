using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model.DAO
{
	public class TourReservationDAO
	{
		private readonly TourReservationRepository _repository;
		private List<TourReservation> _reservations;
        private TourDAO _tourDAO;

        public TourReservationDAO()
        {
            _repository = new TourReservationRepository();
            _reservations = new List<TourReservation>();
            _tourDAO = new TourDAO();

            Load();
        }

        public void Load()
        {
            _reservations = _repository.Load();
        }

        public void Save() 
        {
            _repository.Save(_reservations);
        }

        public List<TourReservation> GetAll()
        {
            return _reservations;
        }

        public int GenerateId()
        {
            if(_reservations.Count == 0) return 0;
			return _reservations.Max(s => s.Id) + 1;
		}

        public void CreateTourReservation(Tour tour, int passengers)
        {
            TourReservation reservation = new TourReservation();

            reservation.Id = GenerateId();
            reservation.Tour = tour;
            reservation.NumberOfVisitors = passengers;

			_reservations.Add(reservation);

			Save();
        }

        public int CheckAvailability(int id)
        {
            int availability = _tourDAO.FindById(id).MaxVisitors;
            int busyness = 0;


			foreach (TourReservation res in _reservations)
            {
                if (res.Tour.Id == id)
                {
                    busyness += res.NumberOfVisitors;
                }
            }

            return availability - busyness;
        }
    }
}
