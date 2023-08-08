using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Model.Images
{
    public class GuestsAccommodationImages : ISerializable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public AccommodationAndOwnerGrade Grade { get; set; }
        public User Guest { get; set; }

        public GuestsAccommodationImages()
        {
            Grade = new AccommodationAndOwnerGrade();
            Guest = new User();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Grade.Id = int.Parse(values[1]);
            Url = values[2];
            Guest.Id = int.Parse(values[3]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Grade.Id.ToString(),
                Url,
                Guest.Id.ToString(),
            };
            return csvValues;
        }
    }
}
