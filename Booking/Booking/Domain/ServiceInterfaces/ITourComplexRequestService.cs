using Booking.Domain.Model;
using System.Collections.Generic;

namespace Booking.Domain.ServiceInterfaces
{
	public interface ITourComplexRequestService : IService<TourComplexRequest>
	{
		List<TourComplexRequest> GetAll();
		List<TourComplexRequest> GetRequestsByUserId(int id);
		TourComplexRequest AddTourRequest(TourComplexRequest tr);
	}
}
