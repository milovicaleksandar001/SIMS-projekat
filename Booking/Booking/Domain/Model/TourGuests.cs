using Booking.Observer;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Model
{
    public class TourGuests : ISerializable
    {
        public Tour Tour { get; set; }
        public User User { get; set; }
        public TourKeyPoint TourKeyPoint { get; set; }
        public bool Voucher { get; set; }
        public bool IsPresent { get; set; }

        public TourGuests() 
        {
            Tour = new Tour();
            User = new User();
            TourKeyPoint = new TourKeyPoint();
            IsPresent = false;

		}

        public void FromCSV(string[] values)
        {
            Tour.Id = int.Parse(values[0]);
            User.Id = int.Parse(values[1]);
            TourKeyPoint.Id = int.Parse(values[2]);
            Voucher = Convert.ToBoolean(values[3]);
			IsPresent = Convert.ToBoolean(values[4]);
		}

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Tour.Id.ToString(),
                User.Id.ToString(),
                TourKeyPoint.Id.ToString(),
                Voucher.ToString(),
				IsPresent.ToString()
			};
            return csvValues;
        }

    }
}
