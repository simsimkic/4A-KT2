using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    class EndedAccommodationReservation : Accommodation
    {
        public int AccommodationId { get; set; }
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public int GuestNumber { get; set; }
        public int DaysForReservation { get; set; }
        public CustomDateTime StartDate { get; set; }
        public CustomDateTime EndDate { get; set; }
        public bool IsGraded { get; set; }

        public int DaysAfterEndingReservation { get; set; }


        public EndedAccommodationReservation(int accommodationId, int reservationId, int guestNumber, int daysForReservation, CustomDateTime startDate, CustomDateTime endDate, int daysAfterEndingReservation)
        {
            this.AccommodationId = accommodationId;
            this.ReservationId = reservationId;
            this.GuestId = 2;
            this.GuestNumber = guestNumber;
            this.DaysForReservation = daysForReservation;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DaysAfterEndingReservation = daysAfterEndingReservation;
            this.IsGraded = false;
        }

        public EndedAccommodationReservation(int accommodationId, int reservationId, int guestNumber, int daysForReservation, int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear, int daysAfterEndingReservation)
        {
            this.AccommodationId = accommodationId;
            this.ReservationId = reservationId;
            this.GuestId = 2;
            this.GuestNumber = guestNumber;
            this.DaysForReservation = daysForReservation;
            this.StartDate = new CustomDateTime(startDay, startMonth, startYear);
            this.EndDate = new CustomDateTime(endDay, endMonth, endYear);
            this.DaysAfterEndingReservation = daysAfterEndingReservation;
            this.IsGraded = false;

        }



        public override string? ToString()
        {
            return "|" + AccommodationId + "|" + ReservationId + "|" + GuestId + "|" + GuestNumber + "|" + DaysForReservation + "|" + StartDate.ToString() + "|" + EndDate.ToString() + "|" + IsGraded.ToString();
        }

        public EndedAccommodationReservation() { }

    }
}
