using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
   internal class CustomDateTime
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public CustomDateTime()
        { }

        public CustomDateTime(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public override string? ToString()
        {
            return Day + "/" + Month + "/" + Year;
        }
    }
}
