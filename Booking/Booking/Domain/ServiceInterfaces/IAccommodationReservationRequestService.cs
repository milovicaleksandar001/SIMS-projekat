using Booking.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IAccommodationReservationRequestService : IService<AccommodationReservationRequests>, ISubject
    {

        void DeleteRequest(AccommodationReservation selectedReservation);
        void Create(AccommodationReservation selectedResrevation, DateTime newArrivalDay, DateTime newDepartureDay);
        List<AccommodationReservationRequests> GetAll();
        List<AccommodationReservationRequests> GetSeeableDateChanges();
        String CheckDate(AccommodationReservationRequests request);
        void SaveRejected(AccommodationReservationRequests request);
        void SaveAccepted(AccommodationReservationRequests request);

    }
}
