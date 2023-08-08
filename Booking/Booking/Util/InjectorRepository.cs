using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Repository;
using Booking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Util
{
	public class InjectorRepository
	{
		private static Dictionary<Type, object> _implementations = new Dictionary<Type, object>
		{
			{ typeof(ITourRepository), new TourRepository() },
			{ typeof(ILocationRepository), new LocationRepository() },
			{ typeof(IUserRepository), new UserRepository() },
			{ typeof(ITourImageRepository), new TourImageRepository() },
			{ typeof(ITourKeyPointRepository), new TourKeyPointRepository() },
			{ typeof(ITourGuestsRepository), new TourGuestsRepository() },
			{ typeof(ITourReservationRepository), new TourReservationRepository() },
			{ typeof(IVoucherRepository), new VoucherRepository() },
			{ typeof(IGuestsAccommodationImagesRepository), new GuestsAccommodationImagesRepository() },
			{ typeof(IAccommodationResevationRepository), new AccommodationResevationRepository() },
			{ typeof(IAccommodationReservationRequestsRepostiory), new AccommodationReservationRequestsRepostiory() },
			{ typeof(IAccommodationRepository), new AccommodationRepository() },
			{ typeof(IAccommodationImagesRepository), new AccommodationImagesRepository() },
			{ typeof(IAccommodationGradeRepository), new AccommodationGradeRepository() },
			{ typeof(IAccommodationAndOwnerGradeRepository), new AccommodationAndOwnerGradeRepository() },
			{ typeof(ITourGradeRepository), new TourGradeRepository() },
            { typeof(INotificationRepository), new NotificationRepository() },
			{ typeof(ITourRequestRepository), new TourRequestRepository() },
			{ typeof(IRenovationRecommodationRepository), new RenovationRecommodationRepository() },
			{ typeof(ISuperGuestRepository), new SuperGuestRepository() },
			{ typeof(IAccommodationRenovationRepository), new AccommodationRenovationRepository() },
			{ typeof(ITourNotificationRepository), new TourNotificationRepository() },
			{ typeof(ISuperGuideRepository), new SuperGuideRepository() },
			{ typeof(ITourComplexRequestRepository), new TourComplexRequestRepository() },
			{ typeof(IForumRepository), new ForumRepository() },
			{ typeof(IForumCommentRepository), new ForumCommentRepository() }
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
