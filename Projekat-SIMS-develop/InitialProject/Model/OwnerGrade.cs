using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    class OwnerGrade
    {

        public int guestId { get; set; }

        public int ownerId { get; set; }

        public int accommodationId { get; set; }

        public int purity { get; set; }

        public int ownerCorrectness { get; set; }

        public string comment { get; set; }


        public OwnerGrade(int guestId, int ownerId, int accommodationId, int purity, int ownerCorrectness, string comment)
        {
            this.guestId = guestId;
            this.ownerId = ownerId;
            this.accommodationId = accommodationId;
            this.purity = purity;
            this.ownerCorrectness = ownerCorrectness;
            this.comment = comment;
        }


        public override string? ToString()
        {
            return "|" + guestId + "|" + ownerId + "|" + purity + "|" + ownerCorrectness + "|" + comment;
        }

    }
}
