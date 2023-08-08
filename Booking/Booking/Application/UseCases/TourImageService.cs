using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.UseCases
{
    public class TourImageService : ITourImageService
    {
        private readonly ITourRepository _tourRepository;
        private readonly ITourImageRepository _tourImageRepository;
        private readonly List<IObserver> _observers;
        public TourImageService()
        {
            _tourRepository = InjectorRepository.CreateInstance<ITourRepository>();
            _tourImageRepository = InjectorRepository.CreateInstance<ITourImageRepository>();
            _observers = new List<IObserver>();
        }

        public TourImage RemoveTourImage(TourImage image) 
        {
            TourImage tourImage = _tourImageRepository.GetByUrl(image.Url);//GetById(image.Id); 
            if(tourImage == null) return null;

            _tourImageRepository.Delete(tourImage);
            NotifyObservers();
            return tourImage;
        }

        public List<TourImage> GetImagesByTourId(int tourId)
        {
            return _tourImageRepository.GetTourImagesByTourId(tourId);
        }

        public List<TourImage> GetImagesFromStartedTourId()
        {
            List<TourImage> list = new List<TourImage>();
            Tour tour = _tourRepository.GetStartedTour();

            if (tour.Description != null)
            {
                foreach (TourImage image in _tourImageRepository.GetAll())
                {
                    if (image.Tour.Id == tour.Id)
                    {
                        list.Add(image);
                    }
                }
                return list;
            }
            else
                return list;
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
