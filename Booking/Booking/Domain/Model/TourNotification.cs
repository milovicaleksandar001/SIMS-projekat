using Booking.Model;
using Booking.Serializer;
using System;

namespace Booking.Domain.Model
{
	public class TourNotification : ISerializable
	{
		public int Id { get; set; }
		public User User { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
		public Tour Tour { get; set; }
		public DateTime CreatedTime { get; set; }

		public TourNotification()
		{
			User = new User();
			Tour = new Tour();
		}

		public void FromCSV(string[] values)
		{
			Id = int.Parse(values[0]);
			User.Id = int.Parse(values[1]);
			Message = values[2];
			IsRead = bool.Parse(values[3]);
			Tour.Id = int.Parse(values[4]);
			CreatedTime = DateTime.Parse(values[5]);
		}

		public string[] ToCSV()
		{
			string[] csvValues =
			{
				Id.ToString(),
				User.Id.ToString(),
				Message,
				IsRead.ToString(),
				Tour.Id.ToString(),
				CreatedTime.ToString("dd/MM/yyyy")
			};
			return csvValues;
		}
	}
}
