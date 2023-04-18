using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository.Interface
{
    internal interface IGuestGradeRepository
    {
        GuestGrade Create(GuestGrade guestGrade);

        IEnumerable<GuestGrade> GetAll();

        IEnumerable<GuestGrade> GetByGuestId(int guestId);

        IEnumerable<GuestGrade> GetById(int accommodationId);

        IEnumerable<GuestGrade> GetByOwnerId(int ownerId);

        IEnumerable<GuestGrade> GetByPurity(int purity);

        IEnumerable<GuestGrade> GetByFollowingRules(int followingRules);
    }
}
