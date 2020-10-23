using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Trail
{
    public class TrailEdit
    {
        public string Name { get; set; }
        public int? CityID { get; set; }
        public int? ParkID { get; set; }
        public int Rating { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public string TypeOfTerrain { get; set; }
        public string Tags { get; set; }
        public string ListOfAllPossibleTags { get; set; }
        public int Elevation { get; set; }
        public string RouteType { get; set; }
    }
}
