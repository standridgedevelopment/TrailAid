using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Models.Trail;

namespace TrailAid.Models.Park
{
    public class ParkDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int? StateID { get; set; }
        public string StateName { get; set; }
        public int Acreage { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public double AverageTrailRating { get; set; }
        public List<TrailDetail> TrailsInPark { get; set; }
    }
}
