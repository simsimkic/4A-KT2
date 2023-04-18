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
    class OwnerGradeRepository : IOwnerGradeRepository
    {

        private string PathToOwnerGradeData = "../../../Resources/Data/OwnerGrade.txt"; 
        private string Delimiter = "|";
        public OwnerGrade OwnerGrade;



        public OwnerGradeRepository(string path, string delimiter)
        {
            PathToOwnerGradeData = path;
            Delimiter = delimiter;
        }

        public OwnerGradeRepository()
        {

        }

        public OwnerGrade Create(OwnerGrade ownerGrade)
        {
            AppendLineToFile(PathToOwnerGradeData, ConvertOwnerGradeToCSVFormat(ownerGrade));
            return ownerGrade;
        }

        public IEnumerable<OwnerGrade> GetAll()
        {
            List<string> lines = File.ReadAllLines(PathToOwnerGradeData).ToList();
            List<OwnerGrade> ownerGrades = new List<OwnerGrade>();
            foreach (string line in lines)
            {
                if (line == "") continue;
                ownerGrades.Add(ConvertCSVFormatToOwnerGrade(line));
            }
            return ownerGrades;
        }

        public IEnumerable<OwnerGrade> GetByGuestId(int guestId)
        {
            List<OwnerGrade> allOwnerGrades = GetAll().ToList();
            List<OwnerGrade> matchedOwnerGrades = new List<OwnerGrade>();

            foreach (OwnerGrade ownerGrade in allOwnerGrades)
            {
                if (ownerGrade.guestId == guestId)
                {
                    matchedOwnerGrades.Add(ownerGrade);
                }
            }
            return matchedOwnerGrades;
        }

        public IEnumerable<OwnerGrade> GetById(int accommodationId)
        {
            List<OwnerGrade> allOwnerGrades = GetAll().ToList();
            List<OwnerGrade> matchedOwnerGrades = new List<OwnerGrade>();

            foreach (OwnerGrade ownerGrade in allOwnerGrades)
            {
                if (ownerGrade.accommodationId == accommodationId)
                {
                    matchedOwnerGrades.Add(ownerGrade);
                }
            }
            return matchedOwnerGrades;
        }

        public IEnumerable<OwnerGrade> GetByOwnerCorrectness(int ownerCorrectness)
        {
            List<OwnerGrade> allOwnerGrades = GetAll().ToList();
            List<OwnerGrade> matchedOwnerGrades = new List<OwnerGrade>();

            foreach (OwnerGrade ownerGrade in allOwnerGrades)
            {
                if (ownerGrade.ownerCorrectness == ownerCorrectness)
                {
                    matchedOwnerGrades.Add(ownerGrade);
                }
            }
            return matchedOwnerGrades;
        }


        public IEnumerable<OwnerGrade> GetByOwnerId(int ownerId)
        {
            List<OwnerGrade> allOwnerGrades = GetAll().ToList();
            List<OwnerGrade> matchedOwnerGrades = new List<OwnerGrade>();

            foreach (OwnerGrade ownerGrade in allOwnerGrades)
            {
                if (ownerGrade.ownerId == ownerId)
                {
                    matchedOwnerGrades.Add(ownerGrade);
                }
            }
            return matchedOwnerGrades;
        }

        public IEnumerable<OwnerGrade> GetByPurity(int purity)
        {
            List<OwnerGrade> allOwnerGrades = GetAll().ToList();
            List<OwnerGrade> matchedOwnerGrades = new List<OwnerGrade>();

            foreach (OwnerGrade ownerGrade in allOwnerGrades)
            {
                if (ownerGrade.purity == purity)
                {
                    matchedOwnerGrades.Add(ownerGrade);
                }
            }
            return matchedOwnerGrades;
        }



        private OwnerGrade ConvertCSVFormatToOwnerGrade(string ownerGradedCVSFormat)
        {
            var tokens = ownerGradedCVSFormat.Split(Delimiter.ToString());

            return new OwnerGrade(
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
        private string ConvertOwnerGradeToCSVFormat(OwnerGrade ownerGrade)
        {
            return string.Join(Delimiter,
                ownerGrade.guestId.ToString(),
                ownerGrade.ownerId.ToString(),
                ownerGrade.accommodationId.ToString(),
                ownerGrade.purity.ToString(),
                ownerGrade.ownerCorrectness.ToString(),
                ownerGrade.comment
               ); ;
        }


    }
}
