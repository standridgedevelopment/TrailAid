using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class VisitedDetail
    {
        public int? TrailID { get; set; }
        public string TrailName { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public int? ParkID { get; set; }
        public string ParkName { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public bool AddToFavorites { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
