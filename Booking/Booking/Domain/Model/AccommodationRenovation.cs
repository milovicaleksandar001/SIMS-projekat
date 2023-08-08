using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Serializer;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Model
{
    public class AccommodationRenovation : ISerializable
    {
        public int Id { get; set; }

        public Accommodation Accommodation { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }
        public string Description { get; set; }

        public AccommodationRenovation()
        {
            Accommodation = new Accommodation();
        }

        public AccommodationRenovation(Accommodation accommodation, DateTime startDay, DateTime endDay, string description)
        {
            this.Accommodation = accommodation;
            this.StartDay = startDay;
            this.EndDay = endDay;
            this.Description = description;
        }
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Accommodation.Id = int.Parse(values[1]);
            StartDay = DateTime.Parse(values[2]);
            EndDay = DateTime.Parse(values[3]);
            Description = values[4];
        }
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Accommodation.Id.ToString(),
                StartDay.ToString("dd/MM/yyyy"),
                EndDay.ToString("dd/MM/yyyy"),
                Description
        };
            return csvValues;
        }
    }
}
