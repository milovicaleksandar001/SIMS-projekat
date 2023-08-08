using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Domain.Model.Images;
using Booking.Serializer;

namespace Booking.Model
{
    public class AccommodationAndOwnerGrade : ISerializable
    {
        public int Id { get; set; }
        public AccommodationReservation AccommodationReservation { get; set; }
        public int Cleaness { get; set; }
        public int OwnersCourtesy { get; set; }
        public string Comment { get; set; }
        public List<GuestsAccommodationImages> Images { get; set; }

        public AccommodationAndOwnerGrade()
        {
            AccommodationReservation = new AccommodationReservation();
            Images = new List<GuestsAccommodationImages>();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            AccommodationReservation.Id = int.Parse(values[1]);
            Cleaness = int.Parse(values[2]);
            OwnersCourtesy = int.Parse(values[3]);
            Comment = values[4];
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                AccommodationReservation.Id.ToString(),
                Cleaness.ToString(),
                OwnersCourtesy.ToString(),
                Comment,
            };
            return csvValues;
        }
    }
}
