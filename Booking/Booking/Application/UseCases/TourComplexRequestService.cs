using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Repository;
using Booking.Util;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Application.UseCases
{
	public class TourComplexRequestService : ITourComplexRequestService
	{
		private readonly ITourComplexRequestRepository _tourComplexRequestRepository;
		private readonly ITourRequestRepository _tourRequestRepository;
		private readonly ILocationRepository _locationRepository;

		public TourComplexRequestService()
		{
			_tourComplexRequestRepository = InjectorRepository.CreateInstance<ITourComplexRequestRepository>();
			_tourRequestRepository = InjectorRepository.CreateInstance<ITourRequestRepository>();
			_locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
		}

		public List<TourComplexRequest> GetAll()
		{
			List<TourComplexRequest> tourRequests = new List<TourComplexRequest>();

			foreach (var tourComplexRequest in _tourComplexRequestRepository.GetAll())
			{
				foreach (var tourRequest in _tourRequestRepository.GetAll())
				{
					if (tourRequest.PartOfComplexRequest.Id == tourComplexRequest.Id)
					{
						tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);
						tourComplexRequest.Requests.Add(tourRequest);
					}
				}

				tourRequests.Add(tourComplexRequest);
			}

			return tourRequests;
		}

		public List<TourComplexRequest> GetRequestsByUserId(int id)
		{
			List<TourComplexRequest> list = GetAll();
			List<TourComplexRequest> result = new List<TourComplexRequest>();

			var res = list.Where(tr => tr.User.Id == id);
			foreach (var tr in res)
			{
				result.Add(tr);
			}

			return result;
		}

		public TourComplexRequest AddTourRequest(TourComplexRequest tr)
		{
			TourComplexRequest temp = _tourComplexRequestRepository.Add(tr);

			foreach (var v in tr.Requests)
			{
				v.PartOfComplexRequest.Id = temp.Id;
				_tourRequestRepository.Update(v);
			}

			return temp;
		}
	}
}
