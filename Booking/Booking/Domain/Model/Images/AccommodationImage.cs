using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model.Images
{
    public class AccommodationImage: ISerializable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Accommodation Accomodation { get; set; } 

        public AccommodationImage()
        {
            Accomodation = new Accommodation();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Accomodation.Id = int.Parse(values[1]);
            Url = values[2];

        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Accomodation.Id.ToString(),
                Url,
            };
            return csvValues;
        }
    }
}
