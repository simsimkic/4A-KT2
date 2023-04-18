using InitialProject.Controller;
using InitialProject.Model;

using InitialProject.Repository.Interface;

using InitialProject.Repository;

using InitialProject.Service;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject
{
    internal class Test
    {
        static void Main(string[] args)
        {
            string delimiter = "|";
            string FilePathToAccommodations = "../../../Resources/Data/Accommodation.txt";
            string FilePathToTours = "../../../Resources/Data/Tour.txt";
            string FilePathToGuestGrades = "../../../Resources/Data/GuestGrade.txt";
            string FilePath6ToAccommodationReservations = "../../../Resources/Data/AccommodationReservation.txt";
            string FilePathToOwnerGrade = "../../../Resources/Data/OwnerGrade.txt";
            string FilePathToUsers = "../../../Resources/Data/Users.txt";

        


            OwnerGradeRepository ownerGradeRepository = new OwnerGradeRepository(FilePathToOwnerGrade, delimiter);
            OwnerGradeService ownerGradeService = new OwnerGradeService(ownerGradeRepository);


            IEnumerable<OwnerGrade> ownerGrades = ownerGradeRepository.GetAll();


            ownerGradeService.CheckOwners();
           
           
        }
    }
}
