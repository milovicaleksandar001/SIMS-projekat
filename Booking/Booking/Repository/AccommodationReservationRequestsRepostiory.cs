using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using Booking.Model.Enums;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class AccommodationReservationRequestsRepostiory : IAccommodationReservationRequestsRepostiory
    {

        private const string FilePath = "../../Resources/Data/accommodationsReservationsRequests.csv";

        private readonly Serializer<AccommodationReservationRequests> _serializer;

        public List<AccommodationReservationRequests> _accommodationsReservationsRequests;

        public AccommodationReservationRequestsRepostiory()
        {
            _serializer = new Serializer<AccommodationReservationRequests>();
            _accommodationsReservationsRequests = _serializer.FromCSV(FilePath);
		}
        public void Save(List<AccommodationReservationRequests> list) 
        {
            _accommodationsReservationsRequests= list;
            _serializer.ToCSV(FilePath, _accommodationsReservationsRequests);
        }

        public List<AccommodationReservationRequests> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public AccommodationReservationRequests GetById(int id)
		{
			return _accommodationsReservationsRequests.Find(a => a.Id == id);
		}
        public int NextId()
        {
            if (_accommodationsReservationsRequests.Count == 0)
            {
                return 1;
            }
            else
            {
                return _accommodationsReservationsRequests.Max(l => l.Id) + 1;
            }
        }
        public void DeleteRequest(AccommodationReservation selectedReservation)
        {
            _accommodationsReservationsRequests.RemoveAll(request => request.AccommodationReservation.Id == selectedReservation.Id);
            _serializer.ToCSV(FilePath, _accommodationsReservationsRequests);
        }
        public void Add(AccommodationReservation selectedResrevation, DateTime newArrivalDay, DateTime newDepartureDay)
        {
            AccommodationReservationRequests newRequest = new AccommodationReservationRequests();

            newRequest.Id = NextId();
            newRequest.AccommodationReservation = selectedResrevation;
            newRequest.NewArrivalDay = newArrivalDay;
            newRequest.NewDeparuteDay = newDepartureDay;
            newRequest.Status = RequestStatus.PENDNING;
            newRequest.Comment = String.Empty;
            _accommodationsReservationsRequests.Add(newRequest);
            _serializer.ToCSV(FilePath, _accommodationsReservationsRequests);
        }
    }
}
