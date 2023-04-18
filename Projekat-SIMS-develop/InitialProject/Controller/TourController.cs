using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    public class TourController
    {

        private readonly TourService tourService;

        public TourController(TourService tourService)
        {
            this.tourService = tourService;
        }

        public Tour Create(Tour tour)
        {
            return tourService.Create(tour);

        }
        public IEnumerable<Tour> GetAll()
        {
            return tourService.GetAll();
        }

        public IEnumerable<Tour> GetByLocation(Location location)
        {
            return tourService.GetByLocation(location);
        }

        public IEnumerable<Tour> GetByLocationCountry(string country)
        {
            return tourService.GetByLocationCountry(country);
        }

        public IEnumerable<Tour> GetByLocationCity(string city)
        {
            return tourService.GetByLocationCity(city);
        }

        public IEnumerable<Tour> GetByDuration(int duration)
        {
            return tourService.GetByDuration(duration);
        }
        public IEnumerable<Tour> GetByLanguage(string language)
        {
            return tourService.GetByLanguage(language);
        }
        public IEnumerable<Tour> GetByGuestNumber(int guestNumber)
        {
            return tourService.GetByGuestNumber(guestNumber);
        }

    }
}