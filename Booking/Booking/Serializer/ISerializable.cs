using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Serializer
{
	internal interface ISerializable
	{
		string[] ToCSV();
		void FromCSV(string[] values);
	}
}
