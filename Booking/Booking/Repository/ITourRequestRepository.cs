using Booking.Domain.DTO;
using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public interface ITourRequestRepository : IRepository<TourRequest>
    {
		int NextId();
		TourRequest Add(TourRequest tourRequest);
		string GetMostPopularLanguageInLastYear();
        int GetMostPopularLocationIdInLastYear();
        List<TourRequest> GetByLocationId(int id);
        List<TourRequest> GetByLanguage(string language);
        TourRequest Update(TourRequest tourRequest);
    }
}
