using System;
using System.Collections.Generic;
using System.Linq;
using Booking.Serializer;
using System.Text;
using System.Threading.Tasks;
using Booking.Model;

namespace Booking.Domain.Model
{
    public class TourGrade : ISerializable
    {
        public int Id { get; set; }
        public Tour Tour {get; set;}
        public User Guide { get; set;}
        public User Guest { get; set;}
        public int KnowledgeGuideGrade { get; set; }
        public int LanguageGuideGrade { get; set; }
        public int InterestOfTourGrade { get; set; }
        public string Comment { get; set; }
        //public List<GradeImage> images { get; set; }
        public bool Valid { get; set; }
        public TourKeyPoint keyPointJoined { get; set; }
        public string StateAndCity { get; set; }

        public TourGrade()
        {
            Tour = new Tour();
            Guide = new User();
            Guest = new User();
            Valid = true;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Tour.Id = Convert.ToInt32(values[1]);
            Guide.Id = Convert.ToInt32(values[2]);
            Guest.Id = Convert.ToInt32(values[3]);
            KnowledgeGuideGrade = Convert.ToInt32(values[4]);
            LanguageGuideGrade = Convert.ToInt32(values[5]);
            InterestOfTourGrade = Convert.ToInt32(values[6]);
            Comment = Convert.ToString(values[7]);
            Valid = Convert.ToBoolean(values[8]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
             {
                Id.ToString(),                  //0
                Tour.Id.ToString(),            //1
                Guide.Id.ToString(),            //2
                Guest.Id.ToString(),            //3
                KnowledgeGuideGrade.ToString(), //4
                LanguageGuideGrade.ToString(),  //5
                InterestOfTourGrade.ToString(), //6
                Comment,                        //7
                Valid.ToString()                //8
            };
            return csvValues;
        }
    }
}
