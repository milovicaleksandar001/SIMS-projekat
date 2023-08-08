using Booking.Domain.DTO;
using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Repository;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Booking.Application.UseCases
{
	public class TourRequestService : ITourRequestService
	{
		private readonly ITourRequestRepository _tourRequestRepository;
		private readonly ILocationRepository _locationRepository;
		private readonly ITourComplexRequestRepository _tourComplexRequestRepository;

        private readonly List<IObserver> _observers;
        public TourRequestService()
		{
			_tourRequestRepository = InjectorRepository.CreateInstance<ITourRequestRepository>();
			_locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
			_tourComplexRequestRepository = InjectorRepository.CreateInstance<ITourComplexRequestRepository>();

            _observers = new List<IObserver>();

            CheckRequestDate();
		}

		public string GetMostPopularLanguageInLastYear()
		{
			return _tourRequestRepository.GetMostPopularLanguageInLastYear();
		}

		public int GetMostPopularLocationIdInLastYear()
		{
			return _tourRequestRepository.GetMostPopularLocationIdInLastYear();
		}

		public List<TourRequest> GetAll()
		{
			List<TourRequest> tourRequests = new List<TourRequest>();

			foreach (var TourRequest in _tourRequestRepository.GetAll())
			{
				TourRequest.Location = _locationRepository.GetById(TourRequest.Location.Id);
				tourRequests.Add(TourRequest);
			}

			return tourRequests;
		}

		public List<TourRequest> GetAllOnHold()
		{
			List<TourRequest> tourRequests = new List<TourRequest>();

			foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
			{
				if (tourRequest.Status == "On hold")
				{
					tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);
					tourRequests.Add(tourRequest);
				}
			}

			return tourRequests;
		}

        public List<TourRequest> GetAllOnHoldPartOfComplex()
        {
            List<TourRequest> tourRequests = new List<TourRequest>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                tourRequest.PartOfComplexRequest = _tourComplexRequestRepository.GetById(tourRequest.PartOfComplexRequest.Id);

                if (tourRequest.Status == "On hold" && tourRequest.PartOfComplexRequest != null)
                {
                    tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);
                    tourRequests.Add(tourRequest);
                }
            }

            return tourRequests;
        }

        public void Search(ObservableCollection<TourRequest> observe, string city, string country, string numberOfGuests, string language, DateTime? startDate, DateTime? endDate)
		{
			observe.Clear();

			foreach (TourRequest tourRequest in GetAllOnHold())
			{
				tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);

				if (IsCountryValid(country, tourRequest) && IsCityValid(city, tourRequest) && IsNumberOfGuestsValid(numberOfGuests, tourRequest) && IsLanguageOfGuestsValid(language, tourRequest) && IsTourRequestInDateRange(startDate, endDate, tourRequest))
				{
					observe.Add(tourRequest);
				}


			}

		}

		public bool IsCountryValid(string country, TourRequest tourRequest)
		{
			return string.IsNullOrEmpty(country) || country.Equals("All") || tourRequest.Location.State.ToLower().Contains(country.ToLower());
		}

		public bool IsCityValid(string city, TourRequest tourRequest)
		{
			return string.IsNullOrEmpty(city) || tourRequest.Location.City.ToLower().Contains(city.ToLower());
		}

		public bool IsNumberOfGuestsValid(string number, TourRequest tourRequest)
		{
			if (string.IsNullOrEmpty(number))
			{
				return true;
			}

			int guestsNumber;

			if (int.TryParse(number, out guestsNumber))
			{
				return tourRequest.GuestsNumber == guestsNumber;
			}

			return false;
		}

		public bool IsLanguageOfGuestsValid(string language, TourRequest tourRequest)
		{
			return string.IsNullOrEmpty(language) || tourRequest.Language.ToLower().Contains(language.ToLower());
		}

		private bool IsTourRequestInDateRange(DateTime? startDate, DateTime? endDate, TourRequest tourRequest)
		{
			if (startDate == null && endDate == null)
			{
				return true;
			}

			if (startDate == null && tourRequest.StartTime <= endDate)
			{
				return true;
			}

			if (endDate == null && tourRequest.EndTime >= startDate)
			{
				return true;
			}

			if (tourRequest.StartTime <= endDate && tourRequest.EndTime >= startDate)
			{
				return true;
			}

			return false;
		}

		public void ShowAll(ObservableCollection<TourRequest> observe)
		{
			observe.Clear();
			foreach (TourRequest tourRequest in GetAllOnHold())
			{
				tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);
				observe.Add(tourRequest);
			}

		}

		public List<YearlyRequests> GetRequestsByYearAndLocation(int locationId)
		{
			List<YearlyRequests> requestsByYear = new List<YearlyRequests>();

			List<TourRequest> tourRequests = _tourRequestRepository.GetByLocationId(locationId);

			var requestsGroupedByYear = tourRequests.GroupBy(tr => tr.StartTime.Year)
													 .Select(g => new { Year = g.Key, Count = g.Count() });

			foreach (var group in requestsGroupedByYear)
			{
				YearlyRequests yearlyRequests = new YearlyRequests
				{
					Year = group.Year,
					Count = group.Count
				};

				requestsByYear.Add(yearlyRequests);
			}

			return requestsByYear;
		}

		public List<YearlyRequests> GetRequestsByYearAndLanguage(string language)
		{
			List<YearlyRequests> requestsByYear = new List<YearlyRequests>();

			List<TourRequest> tourRequests = _tourRequestRepository.GetByLanguage(language);

			var requestsGroupedByYear = tourRequests.GroupBy(tr => tr.StartTime.Year)
													 .Select(g => new { Year = g.Key, Count = g.Count() });

			foreach (var group in requestsGroupedByYear)
			{
				YearlyRequests yearlyRequests = new YearlyRequests
				{
					Year = group.Year,
					Count = group.Count
				};

				requestsByYear.Add(yearlyRequests);
			}

			return requestsByYear;
		}

		public List<MonthlyRequests> GetRequestsByMonthAndLocation(int locationId, int year)
		{
			List<MonthlyRequests> requestsByMonth = new List<MonthlyRequests>();

			List<TourRequest> tourRequests = _tourRequestRepository.GetByLocationId(locationId);

			var requestsGroupedByMonth = tourRequests.Where(tr => tr.StartTime.Year == year)
													 .GroupBy(tr => tr.StartTime.Month)
													 .Select(g => new { Month = g.Key, Count = g.Count() });

			foreach (var group in requestsGroupedByMonth)
			{
				MonthlyRequests monthlyRequests = new MonthlyRequests
				{
					MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Month),
					Count = group.Count
				};

				requestsByMonth.Add(monthlyRequests);
			}


			return requestsByMonth;
		}

		public List<MonthlyRequests> GetRequestsByMonthAndLanguage(string language, int year)
		{
			List<MonthlyRequests> requestsByMonth = new List<MonthlyRequests>();

			List<TourRequest> tourRequests = _tourRequestRepository.GetByLanguage(language);

			var requestsGroupedByMonth = tourRequests.Where(tr => tr.StartTime.Year == year)
													 .GroupBy(tr => tr.StartTime.Month)
													 .Select(g => new { Month = g.Key, Count = g.Count() });

			foreach (var group in requestsGroupedByMonth)
			{
				MonthlyRequests monthlyRequests = new MonthlyRequests
				{
					MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Month),
					Count = group.Count
				};

				requestsByMonth.Add(monthlyRequests);
			}


			return requestsByMonth;
		}

		public TourRequest AddTourRequest(TourRequest tourRequest)
		{
			tourRequest.User.Id = TourService.SignedGuideId;
			tourRequest.Status = "On hold";
			tourRequest.PartOfComplexRequest.Id = -1;

			_tourRequestRepository.Add(tourRequest);

			return tourRequest;
		}

		public List<TourRequest> GetRequestsByUserId(int id)
		{
			List<TourRequest> list = GetAll();
			List<TourRequest> result = new List<TourRequest>();

			var res = list.Where(tr => tr.User.Id == id);
			foreach (var tr in res)
			{
				if (tr.PartOfComplexRequest.Id == -1)
				{
					result.Add(tr);
				}
			}

			return result;
		}

		public int GetNumberOfRequestsByUserId(int id, string year)
		{
			return ((year.Equals("All")) ? GetRequestsByUserId(id).Count() : GetRequestsByUserId(id).Where(tr => tr.CreatedDate.Year.ToString().Equals(year)).Count()) - GetNumberOfAcceptedRequestsByUserId(id, year);
		}

		public int GetNumberOfAcceptedRequestsByUserId(int id, string year)
		{
			return (year.Equals("All")) ? GetRequestsByUserId(id).Where(tr => tr.Status.Equals("Accepted")).Count() : GetRequestsByUserId(id).Where(tr => tr.Status.Equals("Accepted")).Where(tr => tr.CreatedDate.Year.ToString().Equals(year)).Count();
		}

		public List<string> GetLanguagesByUserId(int id, string year)
		{
			List<string> result = new List<string>();
			if (year.Equals("All"))
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (!result.Contains(tr.Language))
					{
						result.Add(tr.Language);
					}
				}
			}
			else
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (!result.Contains(tr.Language) && tr.CreatedDate.Year.ToString().Equals(year))
					{
						result.Add(tr.Language);
					}
				}
			}
			return result;
		}

		public int GetNumberOfRequestsByLang(int id, string lang, string year)
		{
			return (year.Equals("All")) ? GetRequestsByUserId(id).Where(tr => tr.Language.Equals(lang)).Count() : GetRequestsByUserId(id).Where(tr => tr.CreatedDate.Year.ToString().Equals(year)).Where(tr => tr.Language.Equals(lang)).Count();
		}

		public List<string> GetYearsByUserId(int id)
		{
			List<string> result = new List<string>() { "All" };
			foreach (var tr in GetRequestsByUserId(id))
			{
				if (!result.Contains(tr.CreatedDate.Year.ToString()))
				{
					result.Add(tr.CreatedDate.Year.ToString());
				}
			}
			return result;
		}

		public List<string> GetStatesByUserId(int id, string year)
		{
			List<string> result = new List<string>();
			if (year.Equals("All"))
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (!result.Contains(tr.Location.State))
					{
						result.Add(tr.Location.State);
					}
				}
			}
			else
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (!result.Contains(tr.Location.State) && tr.CreatedDate.Year.ToString().Equals(year))
					{
						result.Add(tr.Location.State);
					}
				}
			}
			return result;
		}

		public int GetNumberOfRequestsByState(int id, string state, string year)
		{
			return (year.Equals("All")) ? GetRequestsByUserId(id).Where(tr => tr.Location.State.Equals(state)).Count() : GetRequestsByUserId(id).Where(tr => tr.CreatedDate.Year.ToString().Equals(year)).Where(tr => tr.Location.State.Equals(state)).Count();
		}

		public List<string> GetCitiesByUserId(int id, string year)
		{
			List<string> result = new List<string>();
			if (year.Equals("All"))
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (!result.Contains(tr.Location.City))
					{
						result.Add(tr.Location.City);
					}
				}
			}
			else
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (!result.Contains(tr.Location.City) && tr.CreatedDate.Year.ToString().Equals(year))
					{
						result.Add(tr.Location.City);
					}
				}
			}
			return result;
		}

		public TourRequest ChangeStatus(TourRequest tourRequest)
		{
			TourRequest oldTourRequest = _tourRequestRepository.GetById(tourRequest.Id);
			if (oldTourRequest == null) return null;

			oldTourRequest.Status = tourRequest.Status;
			oldTourRequest.Notify = tourRequest.Notify;
			oldTourRequest.TourReservedStartTime = tourRequest.TourReservedStartTime;

			return _tourRequestRepository.Update(tourRequest);
		}

        public TourRequest UpdateTourRequest(TourRequest tourRequest)
        {
            TourRequest oldTourRequest = _tourRequestRepository.GetById(tourRequest.Id);
            if (oldTourRequest == null) return null;

            oldTourRequest.Status = tourRequest.Status;
            oldTourRequest.Notify = tourRequest.Notify;
            oldTourRequest.TourReservedStartTime = tourRequest.TourReservedStartTime;
			oldTourRequest.StartTime = tourRequest.StartTime;
			oldTourRequest.EndTime = tourRequest.EndTime;

			NotifyObservers();

            return _tourRequestRepository.Update(tourRequest);
        }

        public int GetNumberOfRequestsByCity(int id, string city, string year)
		{
			return (year.Equals("All")) ? GetRequestsByUserId(id).Where(tr => tr.Location.City.Equals(city)).Count() : GetRequestsByUserId(id).Where(tr => tr.CreatedDate.Year.ToString().Equals(year)).Where(tr => tr.Location.City.Equals(city)).Count();
		}

		public double GetAverageVisitorsByUserId(int id, string year)
		{
			double visitors = 0;
			int size = 0;

			if (year.Equals("All"))
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (tr.Status.Equals("Accepted"))
					{
						size++;
						visitors += tr.GuestsNumber;
					}
				}
			}
			else
			{
				foreach (var tr in GetRequestsByUserId(id))
				{
					if (tr.Status.Equals("Accepted") && tr.CreatedDate.Year.ToString().Equals(year))
					{
						size++;
						visitors += tr.GuestsNumber;
					}
				}
			}

			return size > 0 ? Math.Round(visitors / size, 2) : visitors;
		}

		private void CheckRequestDate()
		{
			foreach (TourRequest tr in GetAllOnHold())
			{
				if (tr.StartTime < DateTime.Now.AddHours(48))
				{
					tr.Status = "Invalid";
					ChangeStatus(tr);
				}
			}
		}

		public List<TourRequest> GetAllNotAccepted()
		{
			List<TourRequest> tourRequests = new List<TourRequest>();

			foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
			{
				if (tourRequest.Status.Equals("On hold") || tourRequest.Status.Equals("Invalid"))
				{
					tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);
					tourRequests.Add(tourRequest);
				}
			}

			return tourRequests;
		}

        public List<TourRequest> GetAllAccepted()
        {
            List<TourRequest> tourRequests = new List<TourRequest>();

            foreach (TourRequest tourRequest in _tourRequestRepository.GetAll())
            {
                if (tourRequest.Status.Equals("Accepted"))
                {
                    tourRequest.Location = _locationRepository.GetById(tourRequest.Location.Id);
                    tourRequests.Add(tourRequest);
                }
            }

            return tourRequests;
        }

        public List<User> CheckUnfulfilledRequest(string lang, Location loc)
		{
			List<User> users = new List<User>();
			foreach (TourRequest tr in GetAllNotAccepted())
			{
				bool isLoc = tr.Location.State.Equals(loc.State) || tr.Location.City.Equals(loc.City);
				bool isLang = tr.Language.Equals(lang);
				if ((isLang || isLoc) && !IsUserContained(users, tr.User))
				{
					users.Add(tr.User);
				}
			}
			return users;
		}

		private bool IsUserContained(List<User> users, User u)
		{
			foreach (User user in users)
			{
				if (user.Id == u.Id)
					return true;
			}
			return false;
		}

		public List<TourRequest> GetByComplexRequestId(int id)
		{
			List<TourRequest> tourRequests = new List<TourRequest>();
			foreach (TourRequest tr in GetAll())
			{
				if (tr.PartOfComplexRequest.Id == id)
				{
					tourRequests.Add(tr);
				}
			}
			return tourRequests;
		}

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
