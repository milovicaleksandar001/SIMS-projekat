using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Model
{
    public class SuperGuide : ISerializable
    {
        public int Id { get; set; }
        public User Guide { get; set; }
        public String Language { get; set; }
        public double AverageGrade { get; set; }
        public int NumberOfTours{ get; set; }


        public SuperGuide()
        {
            Guide = new User();
        }
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Guide.Id = int.Parse(values[1]);
            Language = values[2];
            AverageGrade = double.Parse(values[3]);
            NumberOfTours = int.Parse(values[4]);

        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),              //0
                Guide.Id.ToString(),        //1
                Language,                   //2
                AverageGrade.ToString(),    //3
                NumberOfTours.ToString()    //4
        };
            return csvValues;
        }
    }
}
