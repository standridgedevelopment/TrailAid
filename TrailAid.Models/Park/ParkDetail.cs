using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Park
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ParkDetail
    {
        public string Name { get; set; }
        public string CityName { get; set; }
        public int Acreage { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public double AverageTrailRating { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
