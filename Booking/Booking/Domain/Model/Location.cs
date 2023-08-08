using Booking.Serializer;
using System;

namespace Booking.Model
{
	public class Location : ISerializable
	{
		public int Id { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public Location() { }

		public Location(string state, string city)
		{
			State = state;
			City = city;
		}

		public string[] ToCSV()
		{
			string[] csvValues = {
				Id.ToString(),
				State,
				City
			};
			return csvValues;
		}

		public void FromCSV(string[] values)
		{
			Id = Convert.ToInt32(values[0]);
			State = values[1];
			City = values[2];
		}
	}
}
