using Booking.Serializer;
using System;

namespace Booking.Model
{
    public class Voucher : ISerializable
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime ValidTime { get; set; }
        public bool IsActive { get; set; }

        public Voucher()
        {
            User = new User();
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            User.Id = Convert.ToInt32(values[1]);
            ValidTime = DateTime.Parse(values[2]);
            IsActive = Convert.ToBoolean(values[3]);
        }
        public string[] ToCSV()
        {
            string[] csvValues = {
                Id.ToString(),
                User.Id.ToString(),
                ValidTime.ToString("dd/MM/yyyy"),
                IsActive.ToString()
            };
            return csvValues;
        }

    }
}
