using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Model
{
    public class SuperGuest : ISerializable
    {
        public int Id { get; set; }
        public User Guest { get; set; }
        public int NumberOfReservations { get; set; }   
        public int BonusPoints { get; set; }
        public DateTime ActivationDate { get; set; }
        
        public SuperGuest()
        {
            Guest = new User();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Guest.Id = int.Parse(values[1]);
            NumberOfReservations = int.Parse(values[2]);
            BonusPoints = int.Parse(values[3]);
            ActivationDate = DateTime.Parse(values[4]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Guest.Id.ToString(),
                NumberOfReservations.ToString(),
                BonusPoints.ToString(),
                ActivationDate.ToString("dd/MM/yyyy")
        };
            return csvValues;
        }
    }
}
