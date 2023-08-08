using Booking.Model;
using Booking.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Model
{
    public class ForumComment : ISerializable
    {
        public int Id { get; set; }
        public Forum Forum { get; set; }
        public User User { get; set; } 
        public int Reports { get; set; }
        public string Comment { get; set; }
        public string Visited { get; set; }

        public ForumComment()
        {
            Forum = new Forum();
            User = new User();
        }

        public ForumComment(Forum forum, int userId, int reports, string comment, string visited)
        {
            Forum = forum;
            User.Id = userId;
            Reports = reports;
            Comment = comment;
            Visited = visited;
        }
        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Forum.Id.ToString(), User.Id.ToString(), Reports.ToString(), Comment, Visited};
            return csvValues;
        }
        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Forum.Id = Convert.ToInt32(values[1]);
            User.Id = Convert.ToInt32(values[2]);
            Reports = Convert.ToInt32(values[3]);
            Comment = values[4];
            Visited = values[5];
        }
    }
}
