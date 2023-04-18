using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    internal class AccommodationController
    {
        private readonly AccommodationService accommodationService;

        public AccommodationController(AccommodationService accommodationService)
        {
            this.accommodationService = accommodationService;
        }

        public Accommodation Create(Accommodation accommodation)
        {
            return accommodationService.Create(accommodation);
        }
        public IEnumerable<Accommodation> GetAll()
        {
            return accommodationService.GetAll();
        }

        public IEnumerable<Accommodation> GetByName(string name)
        {
            return accommodationService.GetByName(name);
        }

        public IEnumerable<Accommodation> GetByLocation(Location location)
        {
            return accommodationService.GetByLocation(location);
        }

        public IEnumerable<Accommodation> GetByLocationCountry(string country)
        {
            return accommodationService.GetByLocationCountry(country);
        }

        public IEnumerable<Accommodation> GetByLocationCity(string city)
        {
            return accommodationService.GetByLocationCity(city);
        }

        public IEnumerable<Accommodation> GetByType(int type)
        {
            return accommodationService.GetByType(type);
        }



        public IEnumerable<Accommodation> GetByDaysForReservation(int daysForReservation)
        {
            return accommodationService.GetByDaysForReservation(daysForReservation);
        }

    }
}
