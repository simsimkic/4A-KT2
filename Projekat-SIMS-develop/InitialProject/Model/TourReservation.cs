using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    internal class TourReservation
    {
        public int Id { get; set; }
        public int TourId { get; set; } 

        public int NumberOfGuests { get; set; }

        public TourReservation() { }    

        public TourReservation(int id, int tourId, int numberOfGuests)
        {
            Id = id;
            TourId = tourId;
            NumberOfGuests = numberOfGuests;

        }
    }
}
