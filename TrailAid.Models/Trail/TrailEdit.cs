using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Trail
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TrailEdit
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// trail name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// city id
        /// </summary>
        public int? CityID { get; set; }
        /// <summary>
        /// park id
        /// </summary>
        public int? ParkID { get; set; }
        /// <summary>
        /// trail rating
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// trail difficulty
        /// </summary>
        public string Difficulty { get; set; }
        /// <summary>
        /// trail description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// trail distance
        /// </summary>
        public int Distance { get; set; }
        /// <summary>
        /// terrain type
        /// </summary>
        public string TypeOfTerrain { get; set; }
        /// <summary>
        /// ad tags
        /// </summary>
        public string AddTags { get; set; }
        /// <summary>
        /// delete tags
        /// </summary>
        public string DeleteTags { get; set; }
        /// <summary>
        /// trail elevation
        /// </summary>
        public int Elevation { get; set; }
        /// <summary>
        /// trail route type
        /// </summary>
        public string RouteType { get; set; }
    }
}
