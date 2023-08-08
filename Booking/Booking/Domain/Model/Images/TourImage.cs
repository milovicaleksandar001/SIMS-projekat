using Booking.Serializer;

namespace Booking.Model.Images
{
	public class TourImage : ISerializable
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public Tour Tour { get; set; }

		public TourImage()
		{
			Tour = new Tour();
		}
		public void FromCSV(string[] values)
		{
			Id = int.Parse(values[0]);
			Tour.Id = int.Parse(values[1]);
			Url = values[2];
		}

		public string[] ToCSV()
		{
			string[] csvValues = {
				Id.ToString(),
				Tour.Id.ToString(),
				Url
			};
			return csvValues;
		}
	}
}
