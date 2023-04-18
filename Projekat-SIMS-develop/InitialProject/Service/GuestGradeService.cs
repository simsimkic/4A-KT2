using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    internal class GuestGradeService
    {

        private readonly GuestGradeRepository guestGradeRepository;

        public GuestGradeService(GuestGradeRepository guestGradeRepository)
        {
            this.guestGradeRepository = guestGradeRepository;
        }

        public GuestGrade Create(GuestGrade guestGrade)
        {
            return guestGradeRepository.Create(guestGrade);
        }

        internal IEnumerable<GuestGrade> GetAll()
        {
            var guestGrades = guestGradeRepository.GetAll();
            return guestGrades;
        }

    }
}
