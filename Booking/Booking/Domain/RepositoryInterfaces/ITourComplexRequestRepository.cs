using Booking.Domain.Model;

namespace Booking.Domain.RepositoryInterfaces
{
	public interface ITourComplexRequestRepository : IRepository<TourComplexRequest>
	{
		int NextId();
		TourComplexRequest Add(TourComplexRequest tourRequest);
		TourComplexRequest Update(TourComplexRequest tourRequest);
	}
}
