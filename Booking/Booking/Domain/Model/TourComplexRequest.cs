using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;

namespace Booking.Domain.Model
{
	public class TourComplexRequest : ISerializable
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public User User { get; set; }
		public List<TourRequest> Requests { get; set; }

		public TourComplexRequest()
		{
			User = new User();
			Requests = new List<TourRequest>();
		}

		public string[] ToCSV()
		{
			string[] csvValues = {
				Id.ToString(),                                  //0
                CreatedDate.ToString("dd/MM/yyyy"),             //1
                User.Id.ToString()                              //2
            };
			return csvValues;
		}

		public void FromCSV(string[] values)
		{
			Id = Convert.ToInt32(values[0]);
			CreatedDate = DateTime.Parse(values[1]);
			User.Id = Convert.ToInt32(values[2]);
		}
	}
}
