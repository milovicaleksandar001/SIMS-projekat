using Booking.Domain.Model;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface ISuperGuideService : IService<SuperGuide>
    {
        void UpdateSuperGuideStatus(string language);
        int CountGuideTours(string language);
        double GuideAverageGrade(string language);
    }
}
