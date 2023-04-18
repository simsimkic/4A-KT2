using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Service;

namespace InitialProject.Controller
{
    public class TourReservationController
    {
        private readonly TourReservationService tourReservationService;

        public TourReservationController(TourReservationService tourReservationService)
        {
            this.tourReservationService = tourReservationService;
        }
    }
}
