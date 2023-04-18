using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{

    public enum Type { Apartment = 1, House = 2, Hut = 3 }
    internal class Accommodation : Location, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Name { get; set; }

        public Location Location { get; set; }

        public Type Type { get; set; }

        public int MaxGuests { get; set; }

        public int MinDaysForReservation { get; set; }

        public int DaysBeforeCancelingReservation { get; set; }

        public List<string> Pictures { get; set; } = new List<string>();

        public int OwnerId { get; set; }


        public int AccommodationId { get; set; }

        public bool IsGraded { get; set; }

        public bool IsAvailable { get; set; }

        public int _OwnerId
        {
            get
            {
                return OwnerId;
            }
            set
            {
                if (value != OwnerId)
                {
                    OwnerId = value;
                    OnPropertyChanged("OwnerId");
                }
            }
        }

        public List<string> _Pictures
        {
            get
            {
                return Pictures;
            }
            set
            {
                if (value != Pictures)
                {
                    Pictures = value;
                    OnPropertyChanged("Pictures");
                }
            }
        }


        // sdasf

        public int _AccommodationId
        {
            get
            {
                return AccommodationId;
            }
            set
            {
                if (value != AccommodationId)
                {
                    AccommodationId = value;
                    OnPropertyChanged("AccommodationId");
                }
            }
        }

        public bool _IsGraded
        {
            get
            {
                return IsGraded;
            }
            set
            {
                if (value != IsGraded)
                {
                    IsGraded = value;
                    OnPropertyChanged("IsGraded");
                }
            }
        }

        public bool _IsAvailable
        {
            get
            {
                return IsAvailable;
            }
            set
            {
                if (value != IsAvailable)
                {
                    IsAvailable = value;
                    OnPropertyChanged("IsAvailable");
                }
            }
        }


        public int _DaysBeforeCancelingReservation
        {
            get
            {
                return DaysBeforeCancelingReservation;
            }
            set
            {
                if (value != DaysBeforeCancelingReservation)
                {
                    DaysBeforeCancelingReservation = value;
                    OnPropertyChanged("DaysBeforeCancelingReservation");
                }
            }
        }


        public int _MinDaysForReservation
        {
            get
            {
                return MinDaysForReservation;
            }
            set
            {
                if (value != MinDaysForReservation)
                {
                    MinDaysForReservation = value;
                    OnPropertyChanged("MinDaysForReservation");
                }
            }
        }

        public int _MaxGuests
        {
            get
            {
                return MaxGuests;
            }
            set
            {
                if (value != MaxGuests)
                {
                    MaxGuests = value;
                    OnPropertyChanged("MaxGuests");
                }
            }
        }


        public Type _Type
        {
            get
            {
                return Type;
            }
            set
            {
                if (value != Type)
                {
                    Type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public Location _Location
        {
            get
            {
                return Location;
            }
            set
            {
                if (value != Location)
                {
                    Location = value;
                    OnPropertyChanged("Location");
                }
            }
        }

        public string _Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value != Name)
                {
                    Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        //Constructors
        public Accommodation(string name, Location location, Type type, int maxGuests, int minDaysForReservation, int daysBeforeCancelingReservation, List<string> pictures, int ownerId, int accommodationId)
        {
            this.Name = name;
            this.Location = location;
            this.Type = type;
            this.MaxGuests = maxGuests;
            this.MinDaysForReservation = minDaysForReservation;
            this.DaysBeforeCancelingReservation = daysBeforeCancelingReservation;
            this.Pictures = pictures;
            this.OwnerId = ownerId;
            this.AccommodationId = accommodationId;
            this.IsGraded = false;
            this.IsAvailable = true;
        }

        public Accommodation(string name, string locationCity, string locationCountry, Type type, int maxGuests, int minDaysForReservation, int daysBeforeCancelingReservation, List<string> pictures, int ownerId, int accommodationId)
        {
            this.Name = name;
            this.Location = new Location(locationCity, locationCountry);
            this.Type = type;
            this.MaxGuests = maxGuests;
            this.MinDaysForReservation = minDaysForReservation;
            this.DaysBeforeCancelingReservation = daysBeforeCancelingReservation;
            this.Pictures = pictures;
            this.OwnerId = ownerId;
            this.AccommodationId = accommodationId;
            this.IsGraded = false;
            this.IsAvailable = true;

        }

        public Accommodation(string name, Location location, Type type, int maxGuests, int minDaysForReservation, List<string> pictures, int ownerId, int accommodationId)
        {
            this.Name = name;
            this.Location = location;
            this.Type = type;
            this.MaxGuests = maxGuests;
            this.MinDaysForReservation = minDaysForReservation;
            this.DaysBeforeCancelingReservation = 1;
            this.Pictures = pictures;
            this.OwnerId = ownerId;
            this.AccommodationId = accommodationId;
            this.IsGraded = false;
            this.IsAvailable = true;
        }

        public Accommodation(string name, Location location, Type type, int maxGuests, int minDaysForReservation, int daysBeforeCancelingReservation, List<string> pictures)
        {
            this.Name = name;
            this.Location = location;
            this.Type = type;
            this.MaxGuests = maxGuests;
            this.MinDaysForReservation = minDaysForReservation;
            this.DaysBeforeCancelingReservation = daysBeforeCancelingReservation;
            this.Pictures = pictures;
            this.IsGraded = false;
            this.IsAvailable = true;
            this.OwnerId = 1;
            this.AccommodationId++;
        }

        public Accommodation(string name, string locationCity, string locationCountry, Type type, int maxGuests, int minDaysForReservation, int daysBeforeCancelingReservation, List<string> pictures)
        {
            this.Name = name;
            this.Location = new Location(locationCity, locationCountry);
            this.Type = type;
            this.MaxGuests = maxGuests;
            this.MinDaysForReservation = minDaysForReservation;
            this.DaysBeforeCancelingReservation = daysBeforeCancelingReservation;
            this.Pictures = pictures;
            this.IsGraded = false;
            this.IsAvailable = true;
            this.OwnerId = 1;
            this.AccommodationId++;
        }


        public Accommodation()
        {
            this.IsAvailable = true;
            this.OwnerId = 1;
            this.AccommodationId++;
        }

        public Accommodation(string city, string country) : base(city, country)
        {
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return "|" + Name + "|" + Location.City + "|" + Location.Country + "|" + Type + "|" + MaxGuests + "|" + MinDaysForReservation + "|" + DaysBeforeCancelingReservation + "|" +
            string.Join(", ", Pictures) + "|" + OwnerId + "|" + AccommodationId;
        }






    }
}
