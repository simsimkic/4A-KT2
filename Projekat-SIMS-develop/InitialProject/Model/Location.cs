﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Location
    {
        public string City { get; set; }

        public string Country { get; set; }

        public Location() { }


        public Location(string city, string country)
        {
            this.City = city;
            this.Country = country;
        }
    }
}
