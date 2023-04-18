using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository.Interface
{
    interface IEndedAccommodationReservation
    {
        EndedAccommodationReservation Create(EndedAccommodationReservation reservation);

        EndedAccommodationReservation CreateGradedGuest(EndedAccommodationReservation reservation);

        IEnumerable<EndedAccommodationReservation> GetAll();

        public EndedAccommodationReservation GetByAccommodationId(int accommodationId);

        public IEnumerable<EndedAccommodationReservation> GetByReservationId(int reservationId);

        public IEnumerable<EndedAccommodationReservation> GetByGuestId(int guestId);

        public IEnumerable<EndedAccommodationReservation> GetByGuestNumber(int guestNumber);

        public IEnumerable<EndedAccommodationReservation> GetByDaysForReservation(int daysForReservation);

        

    }
}
