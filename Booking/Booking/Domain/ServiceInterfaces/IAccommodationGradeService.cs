using Booking.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IAccommodationGradeService : IService<AccommodationGrade>, ISubject
    {
        AccommodationGrade Create(AccommodationGrade accommodationGrade);
        bool IsReservationGraded(int accommodationReservationId);
        List<AccommodationGrade> GetSeeableGrades();
    }
}
