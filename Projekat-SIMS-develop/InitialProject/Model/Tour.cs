using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics.PerformanceData;
using System.Xml.Linq;
using InitialProject.Model;

namespace InitialProject.Model
{
    public enum Status
    {
        NotStarted = 1,
        InProgress = 2,
        Finished = 3,

    }

    public class Tour : Location   
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int MaxNumOfGuests { get; set; }
        public List<CheckPoint> CheckPoints { get; set; } = new List<CheckPoint>();  
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();

        public Status Status { get; set; }   

        public Tour() { }

        public Tour(string city, string country) : base(city, country) { }

        public List<string> KeyPoint { get; set; } = new List<string>();

        public Tour(int id, string name, Location location, string description, string language, int maxNumOfGuests, List<CheckPoint> checkPoints, DateTime dateTime, int duration, List<string> pictures, Status status)
        {
            this.ID = id;
            this.Name = name;
            this.Location = location;
            this.Description = description;
            this.Language = language;
            this.MaxNumOfGuests = maxNumOfGuests;
            this.CheckPoints = checkPoints;
            this.DateTime = dateTime;
            this.Duration = duration;
            this.Pictures = pictures;
            this.Status = status;

        }

        public Tour(int id, string name, string city, string country, string description, string language, int maxNumOfGuests, List<string> keyPoint, DateTime dateTime, int duration, List<string> pictures, Status status
                                                                                                                                                           )
        {
            this.ID = id;
            this.Name = name;
            this.Location = new Location(city, country);
            this.Description = description;
            this.Language = language;
            this.MaxNumOfGuests = maxNumOfGuests;
            this.KeyPoint = keyPoint;
            this.DateTime = dateTime;
            this.Duration = duration;
            this.Pictures = pictures;

            this.Status = status;
        }


        public override string? ToString()
        {
            return ID + "|" + Name + "|" + Location.City + "|" + Location.Country + "|" + Description + "|" + Language + "|" + MaxNumOfGuests + "|" + string.Join(", ", KeyPoint)  //string.Join(", ", CheckPoints.Select(p => p.ToString())) + "|"// +
             + "|" + DateTime + "|" + Duration + "|" + string.Join(", ", Pictures) + "|" + Status
             ;
        }

    }
}