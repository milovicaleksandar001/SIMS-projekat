using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Serializer;

namespace Booking.Model
{
    public class AccommodationGrade : ISerializable
    {
        public int Id { get; set; }
        public AccommodationReservation Accommodation { get; set; }
        public int Cleanliness { get; set; }
        public int RuleFollowing { get; set; }
        public string Comment { get; set; }
        public int Communication { get; set; }
        public int Lateness { get; set; }

        public AccommodationGrade()
        {
            Accommodation = new AccommodationReservation();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Accommodation.Id = int.Parse(values[1]);
            Cleanliness = int.Parse(values[2]);
            RuleFollowing = int.Parse(values[3]);
            Comment = values[2];
            Communication = int.Parse(values[2]);
            Lateness = int.Parse(values[2]);

        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Accommodation.Id.ToString(),
                Cleanliness.ToString(),
                RuleFollowing.ToString(),
                Comment,
                Communication.ToString(),
                Lateness.ToString(),
            };
            return csvValues;
        }
    }
}
