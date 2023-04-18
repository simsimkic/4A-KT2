using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository.Interface
{
   internal interface IOwnerGradeRepository
    {
        OwnerGrade Create(OwnerGrade ownerGrade);

        IEnumerable<OwnerGrade> GetAll();

        IEnumerable<OwnerGrade> GetByGuestId(int guestId);

        IEnumerable<OwnerGrade> GetById(int accommodationId);

        IEnumerable<OwnerGrade> GetByOwnerId(int ownerId);

        IEnumerable<OwnerGrade> GetByPurity(int purity);

        IEnumerable<OwnerGrade> GetByOwnerCorrectness(int ownerCorrectness);
    }
}
