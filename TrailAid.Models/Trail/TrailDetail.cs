using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Trail
{
    public class TrailDetail
    {
        public string Name { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public int? ParkID { get; set; }
        public string ParkName { get; set; }
        public double Rating { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public string TypeOfTerrain { get; set; }
        public string Tags { get; set; }
        public int Elevation { get; set; }
        public string RouteType { get; set; }
    }
}
