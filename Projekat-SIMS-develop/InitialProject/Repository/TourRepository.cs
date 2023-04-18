using InitialProject.Model;
using InitialProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using InitialProject.Service;
using System.CodeDom;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;

namespace InitialProject.Repository
{
    public class TourRepository : ITourRepository
    {
        private string Path;
        private string Delimiter;


        public TourRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public Tour Create(Tour tour)
        {
            AppendLineToFile(Path, ConvertTourToCSVFormat(tour));
            return tour;

        }


        private string ConvertTourToCSVFormat(Tour tour)
        {
            return string.Join(Delimiter,
                tour.ID.ToString(),
                tour.Name,
                tour.Location.City,
                tour.Location.Country,
                tour.Description,
                tour.Language,
                tour.MaxNumOfGuests.ToString(),
                string.Join(", ", tour.CheckPoints.Select(p => p.ToString())),
                tour.DateTime,
                tour.Duration.ToString(),
                string.Join(", ", tour.Pictures),
                tour.Status.ToString()
               ); ;
        }



        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }

        public IEnumerable<Tour> GetAll()
        {
            List<string> lines = File.ReadAllLines(Path).ToList();
            List<Tour> tours = new List<Tour>();
            foreach (string line in lines)
            {
                if (line == "") continue;
                tours.Add(ConvertCSVFormatToTour(line));
            }
            return tours;

        }
        public IEnumerable<Tour> GetByLocation(Location location)
        {
            List<Tour> allTours = GetAll().ToList();
            List<Tour> matchedTours = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Location.City == location.City && tour.Location.Country == location.Country)
                {
                    matchedTours.Add(tour);
                }
            }
            return matchedTours;
        }


        public IEnumerable<Tour> GetByLocationCity(string city)
        {
            List<Tour> allTours = GetAll().ToList();
            List<Tour> matchedTours = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Location.City.Contains(city))
                {
                    matchedTours.Add(tour);
                }
            }
            return matchedTours;
        }



        public IEnumerable<Tour> GetByLocationCountry(string country)
        {
            List<Tour> allTours = GetAll().ToList();
            List<Tour> matchedTours = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Location.Country.Contains(country))
                {
                    matchedTours.Add(tour);
                }
            }
            return matchedTours;
        }

        public IEnumerable<Tour> GetByDuration(int duration)
        {
            List<Tour> allTours = GetAll().ToList();
            List<Tour> matchedTours = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Duration == duration)
                {
                    matchedTours.Add(tour);
                }
            }
            return matchedTours;
        }
        public IEnumerable<Tour> GetByLanguage(string language)
        {
            List<Tour> allTours = GetAll().ToList();
            List<Tour> matchedTours = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Language.Contains(language))
                {
                    matchedTours.Add(tour);
                }
            }
            return matchedTours;
        }
        public IEnumerable<Tour> GetByGuestNumber(int guestNumber)
        {
            List<Tour> allTours = GetAll().ToList();
            List<Tour> matchedTours = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.MaxNumOfGuests >= guestNumber)
                {
                    matchedTours.Add(tour);
                }
            }
            return matchedTours;
        }



        private Tour ConvertCSVFormatToTour(string tourCSVFormat)
        {
            var tokens = tourCSVFormat.Split(Delimiter.ToCharArray());
            Enum.TryParse(tokens[11], true, out Status status);

            return new Tour(
                int.Parse(tokens[0]),
                tokens[1],
                tokens[2],
                tokens[3],
                tokens[4],
                tokens[5],
                int.Parse(tokens[6]),
                new List<string>() { tokens[7] },
                DateTime.Parse(tokens[8]),
                int.Parse(tokens[9]),
                new List<string>() { tokens[10] },
                status

                );

        }

        public string GetTrackingTourName()
        {
            Console.WriteLine("Insert name of the tour that you want to start: ");
            string trackingTourName = Console.ReadLine();

            return trackingTourName;


        }

        public List<Tour> GetToursForToday()
        {
            List<Tour> todayTours = new List<Tour>();

            foreach (Tour tour in GetAll())
            {

                if (tour.DateTime == DateTime.Now)
                {
                    todayTours.Add(tour);
                }

            }

            return todayTours;

        }

        public Tour GetStartedTour()
        {
            List<Tour> todayTours = GetToursForToday();
            string trackingTourName = GetTrackingTourName();

            foreach (Tour tour in todayTours)
            {
                if (tour.Name.Equals(trackingTourName))
                {
                    tour.Status = Status.InProgress;

                    foreach (CheckPoint checkPoint in tour.CheckPoints)
                    {
                        if (checkPoint.Type == CheckPointType.Start)
                        {
                            checkPoint.IsCovered = true;
                            break;
                        }

                    }

                    return tour;

                }

            }

            return null;

        }

        public void ShowCheckpoints(Tour startedTour)
        {
            foreach (CheckPoint checkPoint in startedTour.CheckPoints)
            {
                Console.Write(checkPoint.ToString());
            }

        }


        public void LiveTourTracking()
        {

            Tour startedTour = GetStartedTour();
            Console.WriteLine("Tour { tour.Name } just started!");

            ShowCheckpoints(startedTour);
            Menu(startedTour);




        }


        public void MenuOptions()
        {
            Console.WriteLine("1.Mark checkpoint");
            Console.WriteLine("2.Mark present tourists");
            Console.WriteLine("3.Finish tour");
            Console.WriteLine("x. exit");
            Console.WriteLine("Select option: ");

        }

        public void Menu(Tour startedTour)
        {
            string chosenOption;
            Console.WriteLine("----MENU----");

            do
            {
                MenuOptions();
                chosenOption = Console.ReadLine();
                ChosenOptionFunctions(chosenOption, startedTour);


            } while (!chosenOption.Equals("x"));

        }

        public void ChosenOptionFunctions(string chosenOption, Tour startedTour)
        {

            switch (chosenOption)
            {
                case "1":
                    ShowCheckpoints(startedTour);
                    MarkCheckpoint(startedTour);
                    break;
                case "2":
                    //MarkPresentTourists();
                    break;
                case "3":
                    FinishTour(startedTour);
                    break;
                default:
                    Console.WriteLine("Option does not exist");
                    break;
            }

        }

        public void MarkCheckpoint(Tour startedTour)
        {
            Console.WriteLine("Insert title of the checkpoint you want to mark");
            string title = Console.ReadLine();

            foreach (CheckPoint checkPoint in startedTour.CheckPoints)
            {
                if (checkPoint.Title == title)
                {
                    checkPoint.IsCovered = true;
                }

            }
        }

        public void MarkPresentTourists(Tour startedTour)
        {
            // TO DO
        }

        public void FinishTour(Tour startedTour)
        {
            foreach (CheckPoint checkPoint in startedTour.CheckPoints)
            {
                if (checkPoint.Type == CheckPointType.End)
                {
                    checkPoint.IsCovered = true;
                }

            }


        }

    }

}


        

    