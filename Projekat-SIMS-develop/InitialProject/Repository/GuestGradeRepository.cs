using InitialProject.Model;
using InitialProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject.Repository
{
    public class GuestGradeRepository : IGuestGradeRepository
    {

        private string PathToGuestGradeData = "../../../Resources/Data/GuestGrade.txt";
        private string Delimiter = "|";
        public GuestGrade GuestGrade;

        public GuestGrade Create(GuestGrade guestGrade)
        {
            AppendLineToFile(PathToGuestGradeData, ConvertGuestGradeToCSVFormat(guestGrade));
            return guestGrade;
        }

        public GuestGradeRepository(string path, string delimiter)
        {
            PathToGuestGradeData = path;
            Delimiter = delimiter;
        }

        public GuestGradeRepository()
        {

        }

        public IEnumerable<GuestGrade> GetAll()
        {
            List<string> lines = File.ReadAllLines(PathToGuestGradeData).ToList();
            List<GuestGrade> guestGrades = new List<GuestGrade>();
            foreach (string line in lines)
            {
                if (line == "") continue;
                guestGrades.Add(ConvertCSVFormatToGuestGrade(line));
                

            }

            return guestGrades;
        }

        public IEnumerable<GuestGrade> GetByGuestId(int guestId)
        {
            List<GuestGrade> allGuestGrades = GetAll().ToList();
            List<GuestGrade> matchedGuestGrades = new List<GuestGrade>();

            foreach (GuestGrade guestGrade in allGuestGrades)
            {
                if (guestGrade.guestId == guestId)
                {
                    matchedGuestGrades.Add(guestGrade);
                }
            }
            return matchedGuestGrades;
        }

        public IEnumerable<GuestGrade> GetById(int accommodationId)
        {
            List<GuestGrade> allGuestGrades = GetAll().ToList();
            List<GuestGrade> matchedGuestGrades = new List<GuestGrade>();

            foreach (GuestGrade guestGrade in allGuestGrades)
            {
                if (guestGrade.accommodationId == accommodationId)
                {
                    matchedGuestGrades.Add(guestGrade);
                }
            }
            return matchedGuestGrades;
        }

        public IEnumerable<GuestGrade> GetByPurity(int purity)
        {
            List<GuestGrade> allGuestGrades = GetAll().ToList();
            List<GuestGrade> matchedGuestGrades = new List<GuestGrade>();

            foreach (GuestGrade guestGrade in allGuestGrades)
            {
                if (guestGrade.purity == purity)
                {
                    matchedGuestGrades.Add(guestGrade);
                }
            }
            return matchedGuestGrades;
        }

        public IEnumerable<GuestGrade> GetByFollowingRules(int followingRules)
        {
            List<GuestGrade> allGuestGrades = GetAll().ToList();
            List<GuestGrade> matchedGuestGrades = new List<GuestGrade>();

            foreach (GuestGrade guestGrade in allGuestGrades)
            {
                if (guestGrade.followingRules == followingRules)
                {
                    matchedGuestGrades.Add(guestGrade);
                }
            }
            return matchedGuestGrades;
        }

        public IEnumerable<GuestGrade> GetByOwnerId(int ownerId)
        {
            List<GuestGrade> allGuestGrades = GetAll().ToList();
            List<GuestGrade> matchedGuestGrades = new List<GuestGrade>();

            foreach (GuestGrade guestGrade in allGuestGrades)
            {
                if (guestGrade.ownerId == ownerId)
                {
                    matchedGuestGrades.Add(guestGrade);
                }
            }
            return matchedGuestGrades;
        }
        private GuestGrade ConvertCSVFormatToGuestGrade(string guestGradeCVSFormat)
        {
            var tokens = guestGradeCVSFormat.Split("|");
            return new GuestGrade(
                int.Parse(tokens[0]),
                int.Parse(tokens[1]),
                int.Parse(tokens[2]),
                int.Parse(tokens[3]),
                int.Parse(tokens[4]),
                tokens[5]
                );
        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
        private string ConvertGuestGradeToCSVFormat(GuestGrade guestGrade)
        {
            return string.Join(Delimiter,
                guestGrade.guestId.ToString(),
                guestGrade.ownerId.ToString(),
                guestGrade.purity.ToString(),
                guestGrade.followingRules.ToString(),
                guestGrade.accommodationId.ToString(),
                guestGrade.comment
               ) ; 
        }


    }
}
