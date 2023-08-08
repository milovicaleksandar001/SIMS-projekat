using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Serializer;
using Booking.Model.Enums;
using Booking.Model.Images;

namespace Booking.Model
{
	public class Accommodation : ISerializable
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Location Location { get; set; }

		public AccommodationType Type { get; set; }

		public int Capacity { get; set; } 

		public int MinNumberOfDays { get; set; } 

		public int CancelationPeriod { get; set; } 

		public List<AccommodationImage> Images { get; set; }

		public User Owner { get; set; }

		public Accommodation() 
		{
			Location = new Location();
            Images = new List<AccommodationImage>();
			Owner = new User();

        }

		public Accommodation(string name, Location location, AccommodationType type, int maxNum, int minNum, int cncl, int ownerId) 
		{ 
			Name = name;
			Location = location;
			Type = type;
            Capacity = maxNum;
			MinNumberOfDays = minNum;
			CancelationPeriod = cncl;
            Images = new List<AccommodationImage>();
			Owner.Id = ownerId;
		}

		public string[] ToCSV()
		{
			string[] csvValues = { Id.ToString(), Name, Location.Id.ToString(), Type.ToString(),
				Capacity.ToString(), MinNumberOfDays.ToString(), CancelationPeriod.ToString(), Owner.Id.ToString() };
			return csvValues;
		}

		public void FromCSV(string[] values)
		{
			Id = Convert.ToInt32(values[0]);
			Name = values[1];
			Location.Id = Convert.ToInt32(values[2]);
          
            AccommodationType accommodationType;

            if (Enum.TryParse<AccommodationType>(values[3], out accommodationType))
			{
				Type = accommodationType;
			}
			else
			{
				Type = AccommodationType.APARTMENT;
				System.Console.WriteLine("Doslo je do greske prilikom ucitavanja tipa smestaja");
			}
            Capacity = Convert.ToInt32(values[4]);
			MinNumberOfDays = Convert.ToInt32(values[5]);
			CancelationPeriod = Convert.ToInt32(values[6]);
			Owner.Id = Convert.ToInt32(values[7]);
        }
	}
}
