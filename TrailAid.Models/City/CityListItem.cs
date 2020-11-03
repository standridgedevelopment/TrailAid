﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.City
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CityListItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int? StateID { get; set; }
        public string StateName { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
