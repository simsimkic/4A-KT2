using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InitialProject.Service
{
    public class TourService
    {
        private readonly TourRepository tourRepository;

        public TourService(TourRepository tourRepository)
        {
            this.tourRepository = tourRepository;
        }

        public Tour Create(Tour tour)
        {

            return tourRepository.Create(tour);


        }
        internal IEnumerable<Tour> GetAll()
        {
            var tours = tourRepository.GetAll();
            return tours;
        }

        internal IEnumerable<Tour> GetByLocation(Location location)
        {
            var tours = tourRepository.GetByLocation(location);
            return tours;
        }
        internal IEnumerable<Tour> GetByLocationCity(string city)
        {
            var tours = tourRepository.GetByLocationCity(city);
            return tours;
        }
        internal IEnumerable<Tour> GetByLocationCountry(string country)
        {
            var tours = tourRepository.GetByLocationCountry(country);
            return tours;
        }
        internal IEnumerable<Tour> GetByDuration(int duration)
        {
            var tours = tourRepository.GetByDuration(duration);
            return tours;
        }
        internal IEnumerable<Tour> GetByLanguage(string language)
        {
            var tours = tourRepository.GetByLanguage(language);
            return tours;
        }
        internal IEnumerable<Tour> GetByGuestNumber(int guestNumber)
        {
            var tours = tourRepository.GetByGuestNumber(guestNumber);
            return tours;
        }



    }
}