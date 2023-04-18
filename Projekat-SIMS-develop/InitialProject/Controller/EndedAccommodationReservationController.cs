using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    class EndedAccommodationReservationController
    {
        private readonly EndedAccommodationReservationService accommodationReservationService;

        public EndedAccommodationReservationController(EndedAccommodationReservationService accommodationReservationService)
        {
            this.accommodationReservationService = accommodationReservationService;
        }

        public EndedAccommodationReservation Create(EndedAccommodationReservation accommodationReservation)
        {
            return accommodationReservationService.Create(accommodationReservation);
        }

        public IEnumerable<EndedAccommodationReservation> GetAll()
        {
            return accommodationReservationService.GetAll();
        }

        internal EndedAccommodationReservation GetByAccommodationId(int accommodationId)
        {
            var accommodationReservations = accommodationReservationService.GetByAccommodationId(accommodationId);
            return accommodationReservations;
        }

        internal IEnumerable<EndedAccommodationReservation> GetByReservationId(int reservationId)
        {
            var accommodationReservations = accommodationReservationService.GetByReservationId(reservationId);
            return accommodationReservations;
        }

        internal IEnumerable<EndedAccommodationReservation> GetByGuestId(int guestId)
        {
            var accommodationReservations = accommodationReservationService.GetByGuestId(guestId);
            return accommodationReservations;
        }
        internal IEnumerable<EndedAccommodationReservation> GetByGuestNumber(int guestNumber)
        {
            var accommodationReservations = accommodationReservationService.GetByGuestNumber(guestNumber);
            return accommodationReservations;
        }


        internal IEnumerable<EndedAccommodationReservation> GetByDaysForReservation(int daysForReservation)
        {
            var accommodationReservations = accommodationReservationService.GetByDaysForReservation(daysForReservation);
            return accommodationReservations;
        }
    }
}
