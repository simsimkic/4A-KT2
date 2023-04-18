using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialProject.Model;

namespace InitialProject.Repository.Interface
{
    public interface ITourRepository
    {

        Tour Create(Tour tour);
        IEnumerable<Tour> GetAll();
        IEnumerable<Tour> GetByLocation(Location location);

        IEnumerable<Tour> GetByLocationCity(string city);

        IEnumerable<Tour> GetByLocationCountry(string country);
        IEnumerable<Tour> GetByDuration(int duration);
        IEnumerable<Tour> GetByLanguage(string language);
        IEnumerable<Tour> GetByGuestNumber(int guestNumber);




    }
}