using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Serializer;

namespace Booking.Model
{
	public class User : ISerializable
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }
		public int Years { get; set; }
		public int Super { get; set; }
		public int Wizard { get; set; }

		public User() { }

		public User(string username, string password,int role, int years)
		{
			Username = username;
			Password = password;
			Role = role;
			Years = years;
		}

		public string[] ToCSV()
		{
			string[] csvValues = {
				Id.ToString(),
				Username,
				Password,
				Role.ToString(),
				Years.ToString(),
				Super.ToString(),
				Wizard.ToString()
			};
			return csvValues;
		}

		public void FromCSV(string[] values)
		{
			Id = Convert.ToInt32(values[0]);
			Username = values[1];
			Password = values[2];
			Role = Convert.ToInt32(values[3]);
			Years = Convert.ToInt32(values[4]);
			Super = Convert.ToInt32(values[5]);
			Wizard = Convert.ToInt32(values[6]);
		}
	}
}
