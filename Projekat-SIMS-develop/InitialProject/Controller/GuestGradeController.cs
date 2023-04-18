using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    internal class GuestGradeController
    {
        private readonly GuestGradeService guestGradeService;

        public GuestGradeController(GuestGradeService guestGradeService)
        {
            this.guestGradeService = guestGradeService;
        }

        public GuestGrade Create(GuestGrade guestGrade)
        {
            return guestGradeService.Create(guestGrade);
        }

        public IEnumerable<GuestGrade> GetAll()
        {
            return guestGradeService.GetAll();
        }
    }
}
