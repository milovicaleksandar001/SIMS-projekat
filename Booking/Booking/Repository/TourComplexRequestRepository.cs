using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Repository
{
	internal class TourComplexRequestRepository : ITourComplexRequestRepository
	{
		private const string FilePath = "../../Resources/Data/tourComplexRequests.csv";
		private readonly Serializer<TourComplexRequest> _serializer;
		private List<TourComplexRequest> _tourRequests;

		public TourComplexRequestRepository()
		{
			_serializer = new Serializer<TourComplexRequest>();
			_tourRequests = _serializer.FromCSV(FilePath);
		}

		public TourComplexRequest Add(TourComplexRequest tourRequest)
		{
			tourRequest.Id = NextId();
			_tourRequests.Add(tourRequest);
			_serializer.ToCSV(FilePath, _tourRequests);
			return tourRequest;
		}

		public List<TourComplexRequest> GetAll()
		{
			return _serializer.FromCSV(FilePath);
		}

		public TourComplexRequest GetById(int id)
		{
			return _tourRequests.Find(tr => tr.Id == id);
		}

		public int NextId()
		{
			if (_tourRequests.Count == 0)
			{
				return 1;
			}
			else
			{
				return _tourRequests.Max(t => t.Id) + 1;
			}
		}

		public TourComplexRequest Update(TourComplexRequest tourRequest)
		{
			TourComplexRequest founded = _tourRequests.Find(tr => tr.Id == tourRequest.Id);
			founded = tourRequest;
			_serializer.ToCSV(FilePath, _tourRequests);
			return founded;
		}
	}
}
