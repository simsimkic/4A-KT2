using InitialProject.Model;
using InitialProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    internal class AccommodationRepository : IAccommodationRepository
    {

        private string PathToAccommodationData = "../../../Resources/Data/Accommodation.txt";
        private string Delimiter = "|";
        public Accommodation accommodationData;

        public AccommodationRepository(string path, string delimiter)
        {
            PathToAccommodationData = path;
            Delimiter = delimiter;
        }

        public AccommodationRepository()
        {

        }
  
        public Accommodation Create(Accommodation accommodation)
        {
           AppendLineToFile(PathToAccommodationData, ConvertAccommodationToCSVFormat(accommodation));
            return accommodation;
        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
           
        }

        public IEnumerable<Accommodation> GetAll()
        {
            List<string> lines = File.ReadAllLines(PathToAccommodationData).ToList();
            List<Accommodation> accommodations = new List<Accommodation>();
            foreach (string line in lines)
            {
                if (line == "") continue;
                accommodations.Add(ConvertCSVFormatToAccommodation(line));
            }
            return accommodations;
        }

        public IEnumerable<Accommodation> GetByName(string name)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.Name.Contains(name))
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }

        public IEnumerable<Accommodation> GetByLocation(Location location)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.Location.City == location.City && accommodation.Location.Country == location.Country)
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }
        
        public IEnumerable<Accommodation> GetByLocationCity(string city)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.Location.City.Contains(city))
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }

        public IEnumerable<Accommodation> GetByLocationCountry(string country)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.Location.Country.Contains(country))
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }
        public IEnumerable<Accommodation> GetByType(int type)
        {
            List<Accommodation> allAccommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in allAccommodations)
            {
                if (accommodation.Type == (Model.Type)type)
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }

        public IEnumerable<Accommodation> GetByGuestNumber(int guestNumber)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.MaxGuests >= guestNumber)
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }

        public IEnumerable<Accommodation> GetByDaysForReservation(int daysForReservation)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            List<Accommodation> matchedAccommodations = new List<Accommodation>();

            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.MinDaysForReservation <= daysForReservation)
                {
                    matchedAccommodations.Add(accommodation);
                }
            }
            return matchedAccommodations;
        }

        public Accommodation GetById(int id)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.AccommodationId == id)
                {
                    return accommodation;
                }

            }
            return null;
        }

        public Accommodation GetByOwnerId(int ownerId)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            foreach (Accommodation accommodation in accommodations)
            {
                if (accommodation.OwnerId == ownerId)
                {
                    return accommodation;
                }

            }
            return null;
        }

        private Accommodation ConvertCSVFormatToAccommodation(string accommodationCVSFormat)
        {
            var tokens = accommodationCVSFormat.Split(Delimiter.ToString());
            Enum.TryParse(tokens[3], true, out Model.Type type);
            return new Accommodation(
              tokens[0],
              tokens[1],
              tokens[2],
              type,
              int.Parse(tokens[4]),
              int.Parse(tokens[5]),
              int.Parse(tokens[6]),
              new List<string>() { tokens[7] },
              int.Parse(tokens[8]),
              int.Parse(tokens[9]));
        }

        private string ConvertAccommodationToCSVFormat(Accommodation accommodation)
        {
            List<Accommodation> accommodations = GetAll().ToList();
            foreach (Accommodation accommodation1 in accommodations)
            {
                if (GetById(accommodation1.AccommodationId = accommodation.AccommodationId) != null)
                {
                    accommodation.AccommodationId++;
                }
            }

            return string.Join(Delimiter,
                accommodation.Name,
                accommodation.Location.City,
                accommodation.Location.Country,
                accommodation.Type.ToString(),
                accommodation.MaxGuests.ToString(),
                accommodation.MinDaysForReservation.ToString(),
                accommodation.DaysBeforeCancelingReservation.ToString(),
                string.Join(", ", accommodation.Pictures),
                accommodation.OwnerId.ToString(),
                accommodation.AccommodationId.ToString()
               ); ;
        }

    }
}
