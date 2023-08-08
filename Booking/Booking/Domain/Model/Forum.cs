using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Serializer;

namespace Booking.Domain.Model
{
    public class Forum : ISerializable
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
        public List<ForumComment> Comments { get; set; }
        public string Helpful { get; set; }

        public Forum() 
        {
            Location = new Location();
            Comments = new List<ForumComment>();
            User = new User();
        }

        public Forum(Location location, int userId, string status, string helpful)
        {
            Location = location;
            User.Id = userId;
            Status = status;
            Comments = new List<ForumComment>();
            Helpful = helpful;
        }
        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Location.Id.ToString(), User.Id.ToString(), Status, Helpful };
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Location.Id = Convert.ToInt32(values[1]);
            User.Id = Convert.ToInt32(values[2]);
            Status = values[3];
            Helpful = values[4];
        }

    }
}
