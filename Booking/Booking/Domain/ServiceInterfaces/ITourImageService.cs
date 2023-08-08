using Booking.Model.Images;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface ITourImageService : ISubject, IService<TourImage>
    {
        TourImage RemoveTourImage(TourImage image);
        List<TourImage> GetImagesByTourId(int tourId);
        List<TourImage> GetImagesFromStartedTourId();

    }
}
