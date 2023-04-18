using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    internal class AccommodationService
    {
        private readonly AccommodationRepository accommodationRepository;

        public AccommodationService(AccommodationRepository accommodationRepository)
        {
            this.accommodationRepository = accommodationRepository;
        }

        public Accommodation Create(Accommodation accommodation)
        {
            return accommodationRepository.Create(accommodation);
        }

        internal IEnumerable<Accommodation> GetAll()
        {
            var accommodations = accommodationRepository.GetAll();
            return accommodations;
        }

        internal IEnumerable<Accommodation> GetByName(string name)
        {
            var accommodations = accommodationRepository.GetByName(name);
            return accommodations;
        }
        internal IEnumerable<Accommodation> GetByLocation(Location location)
        {
            var accommodations = accommodationRepository.GetByLocation(location);
            return accommodations;
        }
        internal IEnumerable<Accommodation> GetByLocationCity(string city)
        {
            var accommodations = accommodationRepository.GetByLocationCity(city);
            return accommodations;
        }
        internal IEnumerable<Accommodation> GetByLocationCountry(string country)
        {
            var accommodations = accommodationRepository.GetByLocationCountry(country);
            return accommodations;
        }

        internal IEnumerable<Accommodation> GetByType(int type)
        {
            var accommodations = accommodationRepository.GetByType(type);
            return accommodations;
        }

        internal IEnumerable<Accommodation> GetByGuestNumber(int guestNumber)
        {
            var accommodations = accommodationRepository.GetByGuestNumber(guestNumber);
            return accommodations;
        }

        internal IEnumerable<Accommodation> GetByDaysForReservation(int daysForReservation)
        {
            var accommodations = accommodationRepository.GetByDaysForReservation(daysForReservation);
            return accommodations;
        }

    }
}
