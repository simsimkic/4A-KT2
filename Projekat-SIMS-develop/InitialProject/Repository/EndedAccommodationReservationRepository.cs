using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    class EndedAccommodationReservationRepository
    {
        private string PathToAccommodationReservations = "../../../Resources/Data/AccommodationReservation.txt";
        private string PathToGradedGuests = "../../../Resources/Data/GradedGuests.txt";
        private string Delimiter = "|";
        public EndedAccommodationReservationRepository accommodationReservation;

        public EndedAccommodationReservationRepository(string path, string delimiter)
        {
            PathToAccommodationReservations = path;
            Delimiter = delimiter;
        }

        public EndedAccommodationReservationRepository()
        {

        }

        public EndedAccommodationReservation Create(EndedAccommodationReservation accommodationReservation)
        {
            AppendLineToFile(PathToAccommodationReservations, ConvertAccommodationReservationToCSVFormat(accommodationReservation));
            return accommodationReservation;
        }

        public IEnumerable<EndedAccommodationReservation> GetAll()
        {
            List<string> lines = File.ReadAllLines(PathToAccommodationReservations).ToList();
            List<EndedAccommodationReservation> accommodationsReservations = new List<EndedAccommodationReservation>();
            foreach (string line in lines)
            {
                if (line == "") continue;
                accommodationsReservations.Add(ConvertCSVFormatToAccommodationReservation(line));
            }
            return accommodationsReservations;
        }

        public EndedAccommodationReservation GetByAccommodationId(int accommodationId)
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();

            foreach (EndedAccommodationReservation accommodationReservation in allAccommodationsReservations)
            {
                if (accommodationReservation.AccommodationId == accommodationId)
                {
                    return accommodationReservation;
                }
            }
            return null;
        }

        public IEnumerable<EndedAccommodationReservation> GetByReservationId(int reservationId)
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();
            List<EndedAccommodationReservation> matchedAccommodationsReservations = new List<EndedAccommodationReservation>();

            foreach (EndedAccommodationReservation accommodationReservation in allAccommodationsReservations)
            {
                if (accommodationReservation.ReservationId == reservationId)
                {
                    matchedAccommodationsReservations.Add(accommodationReservation);
                }
            }
            return matchedAccommodationsReservations;
        }

        public IEnumerable<EndedAccommodationReservation> GetByGuestId(int guestId)
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();
            List<EndedAccommodationReservation> matchedAccommodationsReservations = new List<EndedAccommodationReservation>();

            foreach (EndedAccommodationReservation accommodationReservation in allAccommodationsReservations)
            {
                if (accommodationReservation.GuestId == guestId)
                {
                    matchedAccommodationsReservations.Add(accommodationReservation);
                }
            }
            return matchedAccommodationsReservations;

        }

        public IEnumerable<EndedAccommodationReservation> GetByGuestNumber(int guestNumber)
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();
            List<EndedAccommodationReservation> matchedAccommodationsReservations = new List<EndedAccommodationReservation>();

            foreach (EndedAccommodationReservation accommodationReservation in allAccommodationsReservations)
            {
                if (accommodationReservation.GuestNumber == guestNumber)
                {
                    matchedAccommodationsReservations.Add(accommodationReservation);
                }
            }
            return matchedAccommodationsReservations;

        }

        public IEnumerable<EndedAccommodationReservation> GetByDaysForReservation(int daysForReservation)
        {
            List<EndedAccommodationReservation> allAccommodationsReservations = GetAll().ToList();
            List<EndedAccommodationReservation> matchedAccommodationsReservations = new List<EndedAccommodationReservation>();

            foreach (EndedAccommodationReservation accommodationReservation in allAccommodationsReservations)
            {
                if (accommodationReservation.DaysForReservation == daysForReservation)
                {
                    matchedAccommodationsReservations.Add(accommodationReservation);
                }
            }
            return matchedAccommodationsReservations;
        }

        private EndedAccommodationReservation ConvertCSVFormatToAccommodationReservation(string accommodationReservationCVSFormat)
        {
            var tokens = accommodationReservationCVSFormat.Split(Delimiter.ToString());
            int accommodationId = int.Parse(tokens[0]);
            int reservationId = int.Parse(tokens[1]);
            int guestNumber = int.Parse(tokens[2]);
            int daysForReservation = int.Parse(tokens[3]);
            var startDate = tokens[4].Split('/');
            int startDay = int.Parse(startDate[0]);
            int startMonth = int.Parse(startDate[1]);
            int startYear = int.Parse(startDate[2]);
            var endDate = tokens[5].Split("/");
            int endDay = int.Parse(endDate[0]);
            int endMonth = int.Parse(endDate[1]);
            int endYear = int.Parse(endDate[2]);
            int daysAfterEndingReservation = int.Parse(tokens[6]);

            EndedAccommodationReservation reservation = new EndedAccommodationReservation(accommodationId, reservationId, guestNumber, daysForReservation, startDay, startMonth, startYear, endDay, endMonth, endYear, daysAfterEndingReservation);
            return reservation;
        }

        private string ConvertAccommodationReservationToCSVFormat(EndedAccommodationReservation accommodationReservation)
        {
            return string.Join(Delimiter,
                accommodationReservation.AccommodationId.ToString(),
                accommodationReservation.ReservationId.ToString(),
                accommodationReservation.GuestNumber.ToString(),
                accommodationReservation.DaysForReservation.ToString(),
                accommodationReservation.StartDate.ToString(),
                accommodationReservation.EndDate.ToString(),
                accommodationReservation.DaysAfterEndingReservation.ToString(),
                accommodationReservation.GuestId.ToString(),
                accommodationReservation.IsGraded.ToString());
        }

        public bool Delete(int accId)
        {
            List<EndedAccommodationReservation> endAcc = GetAll().ToList();
            List<string> newFile = new List<string>();
            bool isDeleted = false;
            foreach (EndedAccommodationReservation d in endAcc)
            {
                if (d.AccommodationId != accId)
                {
                    newFile.Add(ConvertAccommodationReservationToCSVFormat(d));
                    isDeleted = true;
                }
            }
            File.WriteAllLines(PathToAccommodationReservations, newFile);
            return isDeleted;
        } 

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }

        public EndedAccommodationReservation CreateGradedGuest(EndedAccommodationReservation reservation)
        {
            AppendLineToFile(PathToGradedGuests, ConvertAccommodationReservationToCSVFormat(reservation));
            return reservation;
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
