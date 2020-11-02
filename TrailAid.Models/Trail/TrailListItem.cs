using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Trail
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TrailListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public int? ParkID { get; set; }
        public string ParkName { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
