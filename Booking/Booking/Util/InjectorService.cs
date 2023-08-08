using Booking.Application.UseCases;
using Booking.Domain.ServiceInterfaces;
using Booking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Util
{
    public class InjectorService
    {
        private static Dictionary<Type, object> _implementations = new Dictionary<Type, object>
        {
            { typeof(ITourService), new TourService() },
            { typeof(ITourGuestsService), new TourGuestsService() },
            { typeof(IAccommodationAndOwnerGradeService), new AccommodationAndOwnerGradeService() },
            { typeof(IAccommodationService), new AccommodationService() },
            { typeof(IAccommodationGradeService), new AccommodationGradeService() },
            { typeof(IAccommodationReservationRequestService), new AccommodationReservationRequestService() },
            { typeof(IAccommodationImageService), new AccommodationImageService() },
            { typeof(IVoucherService), new VoucherService() },
            { typeof(IAccommodationReservationService), new AccommodationReservationService() },
            { typeof(IUserService), new UserService() },
            { typeof(ITourReservationService), new TourReservationService() },
            { typeof(IGuestsAccommodationImagesService), new GuestsAccommodationImagesService() },
            { typeof(ILocationService), new LocationService() },
            { typeof(ITourGradeService), new TourGradeService() },
            { typeof(INotificationService), new NotificationService() },
            { typeof(ITourImageService), new TourImageService() },
            { typeof(ITourRequestService), new TourRequestService() },
            { typeof(IRenovationRecommodationService), new RenovationRecommodationService() },
            { typeof(ISuperGuestService), new SuperGuestService() },
            { typeof(IAccommodationRenovationService), new AccommodationRenovationService() },
            { typeof(ITourNotificationService), new TourNotificationService() },
            { typeof(ISuperGuideService), new SuperGuideService() },
            { typeof(ITourComplexRequestService), new TourComplexRequestService() },
            { typeof(IForumService), new ForumService() },
            { typeof(IForumCommentService), new ForumCommentService() }
        };

        public static T CreateInstance<T>()
        {
            Type type = typeof(T);
            if (_implementations.ContainsKey(type))
            {
                return (T)_implementations[type];
            }
            throw new ArgumentException($"No implementation found for type {type}");
        }
    }
}
