using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace InitialProject.Service
{
   internal class OwnerGradeService
    {
        private readonly OwnerGradeRepository ownerGradeRepository = new OwnerGradeRepository("../../../Resources/Data/OwnerGrade.txt", "|");
        string FilePathToOwnerGrade = "../../../Resources/Data/OwnerGrade.txt";
        public OwnerGradeService(OwnerGradeRepository ownerGradeRepository)
        {
            this.ownerGradeRepository = ownerGradeRepository;
        }

        public OwnerGradeService()
        {
            this.ownerGradeRepository = ownerGradeRepository;
        }
        public OwnerGrade Create(OwnerGrade ownerGrade)
        {
            return ownerGradeRepository.Create(ownerGrade);
        }

        internal IEnumerable<OwnerGrade> GetAll()
        {
            var ownerGrades = ownerGradeRepository.GetAll();
            return ownerGrades;
        }

        internal IEnumerable<OwnerGrade>GetByAccommodationId(int id)
        {
            var ownerGrades = ownerGradeRepository.GetById(id);
            return ownerGrades;
        }
        internal IEnumerable<OwnerGrade> GetByGuestId(int id)
        {
            var ownerGrades = ownerGradeRepository.GetByGuestId(id);
            return ownerGrades;
        }

        internal IEnumerable<OwnerGrade> GetByOwnerCorrectness(int correctness)
        {
            var ownerGrades = ownerGradeRepository.GetByOwnerCorrectness(correctness);
            return ownerGrades;
        }

        internal IEnumerable<OwnerGrade> GetByOwnerId(int id)
        {
            var ownerGrades = ownerGradeRepository.GetByOwnerId(id);
            return ownerGrades;
        }

        internal IEnumerable<OwnerGrade> GetByPurity(int purity)
        {
            var ownerGrades = ownerGradeRepository.GetByPurity(purity);
            return ownerGrades;
        }


        public void ShowReviews()
        {
            GuestGradeRepository guestGradeRepository = new GuestGradeRepository("../../../Resources/Data/GuestGrade.txt", "|");
            IEnumerable<GuestGrade> guestGrades = guestGradeRepository.GetAll();

            OwnerGradeRepository ownerGradeRepository = new OwnerGradeRepository("../../../Resources/Data/OwnerGrade.txt", "|");
            IEnumerable<OwnerGrade> ownerGrades = ownerGradeRepository.GetAll();

            foreach (OwnerGrade ownerGrade in ownerGrades)
            {
                foreach (GuestGrade guestGrade in guestGrades)
                {
                    if (guestGrade.guestId == ownerGrade.guestId && guestGrade.ownerId == ownerGrade.ownerId)
                    {
                        Console.WriteLine("Guest with ID: " + ownerGrade.guestId + " graded owner with ID: " + ownerGrade.ownerId + " Purity: " + ownerGrade.purity + " Owner Correctness: " + ownerGrade.ownerCorrectness + " " + ownerGrade.comment);
                        break; // Dodajemo break kako bismo prekinuli unutarnju petlju nakon prvog podudaranja
                    }
                }
            }

        }

        public void CheckOwners()
        {
            OwnerGradeRepository ownerGradeRepository = new OwnerGradeRepository("../../../Resources/Data/OwnerGrade.txt", "|");
            IEnumerable<OwnerGrade> ownerGrades = ownerGradeRepository.GetAll();

            UsersRepository usersRepository = new UsersRepository("../../../Resources/Data/Users.txt", "|");
            IEnumerable<Users> users = usersRepository.GetAll();

            double averageOwnerGrade = 0;
            int numberOfLines = File.ReadAllLines(FilePathToOwnerGrade).Length;
            if(numberOfLines < 50)
            {
                return;
            }



            int ownerCorrectness = 0;

            foreach (OwnerGrade ownerGrade in ownerGrades)
            {
                if (ownerGrade.ownerId == 1)
                {
                    ownerCorrectness += ownerGrade.ownerCorrectness;
                }
            }
           

            averageOwnerGrade = (double)ownerCorrectness / (double)numberOfLines;

          


            if(averageOwnerGrade > 4.5)
            {
                using (StreamWriter writer = new StreamWriter("../../../Resources/Data/SuperOwners.txt",true))
                {
                    foreach(Users user in users)
                    {
                        if(user.Id == 1)
                        {
                            writer.WriteLine("* " + user.Name + "|" + user.Password + "|" + user.Id + "|" + user.Type);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                if(File.Exists("../../../Resources/Data/SuperOwners.txt"))
                {
                    string[] lines = File.ReadAllLines("../../../Resources/Data/SuperOwners.txt");
                    File.WriteAllLines("../../../Resources/Data/SuperOwners.txt", lines.Where(line => !line.StartsWith("*")).ToArray());
                }
            }
;
        }
    }
}
