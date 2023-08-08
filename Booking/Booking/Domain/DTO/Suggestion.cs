using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.DTO
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Reservations { get; set; }
    }
}
