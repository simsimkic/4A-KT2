using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
   internal class OwnerGradeController
    {

        private readonly OwnerGradeService ownerGradeService;

        public OwnerGradeController(OwnerGradeService ownerGradeService)
        {
            this.ownerGradeService = ownerGradeService;
        }

        public OwnerGrade Create(OwnerGrade ownerGrade)
        {
            return ownerGradeService.Create(ownerGrade);
        }

        public IEnumerable<OwnerGrade> GetAll()
        {
            return ownerGradeService.GetAll();
        }
    }
}
