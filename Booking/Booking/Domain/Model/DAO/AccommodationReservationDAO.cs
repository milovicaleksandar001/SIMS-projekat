using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Booking.Controller;
using System.Windows;

namespace Booking.Model.DAO
{
    public class AccommodationReservationDAO
    {
        private readonly AccommodationResevationRepository _accommodationResevationRepository;

        private List<AccommodationReservation> reservations;
        private AccommodationGradeController _accommodationGradeController;
        private AccommodationRepository _accommodationRepository;
        private readonly AccommodationResevationRepository repository;

        public AccommodationReservationDAO()
        {
            reservations = new List<AccommodationReservation>();
            _accommodationResevationRepository = new AccommodationResevationRepository();
            Load();
            _accommodationRepository = new AccommodationRepository();
            repository = new AccommodationResevationRepository();
            reservations = repository.Load();

            var app = Application.Current as App;
            _accommodationGradeController = app.AccommodationGradeController;
            BindReservationToAccommodation();
        }

        public void Load()
        {
            reservations = _accommodationResevationRepository.Load();
        }

        public AccommodationReservation GetByID(int id)
        {
            return reservations.Find(reservation => reservation.Id == id);
        }

        public List<AccommodationReservation> GetAll()
        {
            return reservations;
        }


        public int GenerateId()
        {
            if (reservations.Count == 0) return 0;
            return reservations.Max(s => s.Id) + 1;
        }

         
        public void SaveReservation(AccommodationReservation reservation)
        {
            reservation.Id = GenerateId();
            reservations.Add(reservation);
            _accommodationResevationRepository.Save(reservations);
        }

        public List<DateTime> makeListOfReservedDates(DateTime initialDate, DateTime endDate)
        {
            List<DateTime> reservedDates = new List<DateTime>();
            for (DateTime date = initialDate; date <= endDate; date = date.AddDays(1))
            {
                reservedDates.Add(date);
            }
            return reservedDates;
        }

        public bool IsDatesMatche(List<DateTime> reservedDatesEntered, List<DateTime> reservedDates)
        {
            foreach (DateTime date in reservedDates)
            {
                foreach (DateTime dateEntered in reservedDatesEntered)
                {
                    if (dateEntered == date)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Reserve(DateTime arrivalDay, DateTime departureDay, Accommodation selectedAccommodation)
        {

            List<DateTime> reservedDatesEntered = makeListOfReservedDates(arrivalDay, departureDay);

            foreach (AccommodationReservation reservation in reservations)
            {
                if (reservation.Accommodation.Id == selectedAccommodation.Id)
                {
                    List<DateTime> reservedDates = makeListOfReservedDates(reservation.ArrivalDay, reservation.DepartureDay);

                    if (IsDatesMatche(reservedDatesEntered, reservedDates) == false)
                    {
                        //unsuccessful reservation
                        return false;
                    }
                }
            }
            AccommodationReservation newReservation = new AccommodationReservation(selectedAccommodation, arrivalDay, departureDay);

            //successful reservation
            SaveReservation(newReservation);
            return true;
        }

        public List<DateTime> setReservedDates(DateTime ArrivalDay, DateTime DepartureDay, Accommodation selected)
        {
            //this is list od reserved days
            List<DateTime> reservedDates = new List<DateTime>();

            foreach (AccommodationReservation r in reservations)
            {
                if (r.Accommodation.Id == selected.Id)
                {
                    for (DateTime date = r.ArrivalDay; date <= r.DepartureDay; date = date.AddDays(1))
                    {
                        reservedDates.Add(date);
                    }
                }
            }
            //throw out duplicates
            List<DateTime> uniqueReservedDatesList = reservedDates.Distinct().ToList();

            //sort in ascending order
            uniqueReservedDatesList.Sort();
            return uniqueReservedDatesList;
        }
        private bool IsReservationAvailableToGrade(AccommodationReservation accommodationReservation)
        {
            return accommodationReservation.DepartureDay <= DateTime.Now && accommodationReservation.DepartureDay.AddDays(5) >= DateTime.Now;

        }

        public List<AccommodationReservation> GetAllUngradedReservations()
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            foreach (var reservation in reservations)
            {
                if (IsReservationAvailableToGrade(reservation) == false)
                {
                    continue;
                }
                bool flag = _accommodationGradeController.IsReservationGraded(reservation.Id);
                if (!flag)
                {
                    reservationList.Add(reservation);
                }
            }
            return reservationList;
        }
        public List<(DateTime, DateTime)> GetDates(List<DateTime> reservedDates, int difference, DateTime departureDay, DateTime arrivalDay)
        {
            List<(DateTime, DateTime)> rangeOfDates = new List<(DateTime, DateTime)>();

            DateTime end = departureDay;
            bool flag = true;

            while (flag)
            {
                bool flag2 = false;

                for (int i = 1; i <= difference; i++)
                {
                    foreach (var ReservedDay in reservedDates)
                    {
                        DateTime kt = end;
                        if (kt.AddDays(-i) == ReservedDay || kt.AddDays(-i) == DateTime.Now)
                        {
                            flag2 = true;
                            if (end.AddDays(-i) == DateTime.Now)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }

                if (flag2 == false)
                {
                    rangeOfDates.Add((end.AddDays(-difference), end));
                    flag = false;

                }
                else
                {
                    end = end.AddDays(-1);
                }
            }

            flag = true;
            DateTime start = arrivalDay;

            while (flag)
            {
                bool flag2 = false;

                for (int i = 1; i <= difference; i++)
                {
                    foreach (var ReservedDay in reservedDates)
                    {
                        DateTime pv = start;
                        if (pv.AddDays(i) == ReservedDay)
                        {
                            flag2 = true;
                        }
                    }
                }

                if (flag2 == false)
                {
                    rangeOfDates.Add((start, start.AddDays(difference)));
                    flag = false;

                }
                else
                {
                    start = start.AddDays(1);
                }
            }

            return rangeOfDates;
        }

        public List<(DateTime, DateTime)> SuggestOtherDates(DateTime ArrivalDay, DateTime DepartureDay, Accommodation SelectedAccommodation)
        {
            int difference = (DepartureDay - ArrivalDay).Days;

            List<DateTime> reservedDates = new List<DateTime>();
            reservedDates = setReservedDates(ArrivalDay, DepartureDay, SelectedAccommodation);

            //return the list of ranges
            return GetDates(reservedDates, difference, DepartureDay, ArrivalDay);
        }

        public void BindReservationToAccommodation()
        {
            foreach (AccommodationReservation accommodationReservation in reservations)
            {
                foreach (Accommodation accommodation in _accommodationRepository.Load())
                {
                    if (accommodation.Id == accommodationReservation.Accommodation.Id)
                    {
                        accommodationReservation.Accommodation = accommodation;
                    }
                }
            }

        }
    }
}

