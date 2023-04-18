using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
     internal class EndedAccommodationReservationService
    {
        private readonly EndedAccommodationReservationRepository accommodationReservationRepository;

        public EndedAccommodationReservationService(EndedAccommodationReservationRepository accommodationReservationRepository)
        {
            this.accommodationReservationRepository = accommodationReservationRepository;
        }
        public EndedAccommodationReservationService()
        {
            this.accommodationReservationRepository = accommodationReservationRepository;
        }


        public EndedAccommodationReservation Create(EndedAccommodationReservation accommodationReservation)
        {
            return accommodationReservationRepository.Create(accommodationReservation);
        }

        internal IEnumerable<EndedAccommodationReservation> GetAll()
        {
            var accommodationReservations = accommodationReservationRepository.GetAll();
            return accommodationReservations;
        }

        internal EndedAccommodationReservation GetByAccommodationId(int accommodationId)
        {
            var accommodationReservations = accommodationReservationRepository.GetByAccommodationId(accommodationId);
            return accommodationReservations;
        }

        internal IEnumerable<EndedAccommodationReservation> GetByReservationId(int reservationId)
        {
            var accommodationReservations = accommodationReservationRepository.GetByReservationId(reservationId);
            return accommodationReservations;
        }

        internal IEnumerable<EndedAccommodationReservation> GetByGuestId(int guestId)
        {
            var accommodationReservations = accommodationReservationRepository.GetByGuestId(guestId);
            return accommodationReservations;
        }
        internal IEnumerable<EndedAccommodationReservation> GetByGuestNumber(int guestNumber)
        {
            var accommodationReservations = accommodationReservationRepository.GetByGuestNumber(guestNumber);
            return accommodationReservations;
        }


        internal IEnumerable<EndedAccommodationReservation> GetByDaysForReservation(int daysForReservation)
        {
            var accommodationReservations = accommodationReservationRepository.GetByDaysForReservation(daysForReservation);
            return accommodationReservations;
        }

        public void changeFlag(int endResAccId)
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();
            foreach (EndedAccommodationReservation endedAccommodationReservation in allAccommodationsReservations)
            {
                if (endedAccommodationReservation.AccommodationId == endResAccId)
                {
                    endedAccommodationReservation.IsGraded = true;
                }
            }
        }

        public void AlertOwner()
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();
            foreach (EndedAccommodationReservation endedAccommodationReservation in allAccommodationsReservations)
            {
                if (endedAccommodationReservation.DaysAfterEndingReservation <= 5 && endedAccommodationReservation.IsGraded == false)
                {
                    Console.WriteLine("Vlasnik moze da oceni gosta sa ID-em: " + endedAccommodationReservation.GuestId + " za boravak u smestaju sa ID-em: " + endedAccommodationReservation.AccommodationId);

                }

            }

        }
    }
}
