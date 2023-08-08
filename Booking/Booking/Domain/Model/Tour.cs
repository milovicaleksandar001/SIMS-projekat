using Booking.Model.Images;
using Booking.Serializer;
using System;
using System.Collections.Generic;


namespace Booking.Model
{
    public class Tour : ISerializable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public int MaxVisitors { get; set; }

        public List<TourKeyPoint> Destinations { get; set; }

        public DateTime StartTime { get; set; }

        public double Duration { get; set; }

        public List<TourImage> Images { get; set; }

        public int GuideId { get; set; }

        public bool IsStarted { get; set; }
        public int GuestsAsTour { get; set; }
        public bool IsEnded { get; set; }

        public bool IsCancelable()
        {
            TimeSpan timeUntilStart = StartTime - DateTime.Now;
            return timeUntilStart > TimeSpan.FromHours(48);
        }

        public Voucher Voucher { get; set; }

        public Tour()
        {
            Location = new Location();
            Destinations = new List<TourKeyPoint>();
            Images = new List<TourImage>();
            IsStarted = false;
            IsEnded = false;
        }

        public Tour(string name, Location location, string desc, string lang, int maxVisitors, DateTime dt, double duration, int guideId)
        {
            Name = name;
            Location = location;
            Description = desc;
            Language = lang;
            MaxVisitors = maxVisitors;
            StartTime = dt;
            Duration = duration;
            Destinations = new List<TourKeyPoint>();
            Images = new List<TourImage>();
            GuideId = guideId;
        }

        public string[] ToCSV()
        {
            string[] csvValues = {
                Id.ToString(),                          //0
                Name,                                   //1
                Location.Id.ToString(),                 //2
                Description,                            //3
                Language,                               //4
                MaxVisitors.ToString(),					//5
                StartTime.ToString("dd/MM/yyyy"),		//6
                Duration.ToString(),                    //7
				IsStarted.ToString(),					//8
				GuideId.ToString(),						//9
				IsEnded.ToString(),						//10
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Name = values[1];
            Location.Id = Convert.ToInt32(values[2]);
            Description = values[3];
            Language = values[4];
            MaxVisitors = Convert.ToInt32(values[5]);
            StartTime = DateTime.Parse(values[6]);
            Duration = Convert.ToDouble(values[7]);
            IsStarted = Convert.ToBoolean(values[8]);
            GuideId = Convert.ToInt32(values[9]);
            IsEnded = Convert.ToBoolean(values[10]);
        }
    }
}