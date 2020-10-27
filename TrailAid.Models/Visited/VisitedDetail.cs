using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
    public class VisitedDetail
    {
        public int? TrailID { get; set; }
        public string TrailName { get; set; }
        public string CityName { get; set; }
        public string ParkName { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public string UserName { get; set; }
    }
}
