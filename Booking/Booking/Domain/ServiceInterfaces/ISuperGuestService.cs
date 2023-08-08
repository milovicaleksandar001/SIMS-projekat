using Booking.Domain.Model;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface ISuperGuestService: IService<SuperGuest>
    {
        List<AccommodationReservation> GetGeustsReservatonst(User SignedGuest);
        DateTime SetActivationDate(User SignedGuest);
        void CreateSuperGuest(User signedGuest, int numberOfReservations);
        void CheckNumberOfReservations(User SignedGuest);
        void SetOrdinaryGuest(SuperGuest superGuest, User signedGuest);
        void CheckActivationDate(User SignedGuest);
        void CheckSuperGuest();
        void ReduceBonusPoints();
        int CalculateReservationsForLastYear(User SignedGuest);
        SuperGuest GetSuperBySignedGuestId(int id);

    }
}
