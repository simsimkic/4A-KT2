using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Repository;

namespace InitialProject.Service
{
    public class TourReservationService
    {
        private readonly TourReservationRepository tourReservationRepository;
    
        public TourReservationService(TourReservationRepository tourReservationRepository)
        {
            this.tourReservationRepository = tourReservationRepository;
        }
    }
}
