using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository.Interface
{
    internal interface IAccommodationRepository
    {
        Accommodation Create(Accommodation accommodation);

        IEnumerable<Accommodation> GetAll();

        IEnumerable<Accommodation> GetByName(string name);

        IEnumerable<Accommodation> GetByLocation(Location location);

        IEnumerable<Accommodation> GetByLocationCity(string city);

        IEnumerable<Accommodation> GetByLocationCountry(string country);

        IEnumerable<Accommodation> GetByType(int type);

        Accommodation GetById(int id);

        Accommodation GetByOwnerId(int ownerId);

        IEnumerable<Accommodation> GetByGuestNumber(int guestNumber);

        IEnumerable<Accommodation> GetByDaysForReservation(int daysForReservation);
    }
}
