using Booking.Serializer;
using System;

namespace Booking.Model
{
	public class TourKeyPoint : ISerializable
	{
		public int Id { get; set; }
		public Tour Tour { get; set; }
		public Location Location { get; set; }
		public bool Achieved { get; set; }

		public TourKeyPoint()
		{
			Tour = new Tour();
			Location = new Location();
			Achieved = false;
		}

		public void FromCSV(string[] values)
		{
			Id = int.Parse(values[0]);
			Tour.Id = int.Parse(values[1]);
			Location.Id = Convert.ToInt32(values[2]);
			Achieved = Convert.ToBoolean(values[3]);
		}

		public string[] ToCSV()
		{
			string[] csvValues =
			{
				Id.ToString(),
				Tour.Id.ToString(),
				Location.Id.ToString(),
				Achieved.ToString()
			};
			return csvValues;
		}
	}
}
