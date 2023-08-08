using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.DTO
{
    public class OwnerMonthStatistic
    {
        public string Month { get; set; }
        public int NumberOfReservations { get; set; }
        public int NumberOfCancelations { get; set; }
        public int NumberOfReschedulings { get; set; }
        public int NumberOfSuggestions { get; set; }
    }
}
