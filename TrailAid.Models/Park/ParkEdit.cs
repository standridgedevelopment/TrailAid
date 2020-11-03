using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Park
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ParkEdit
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// city id
        /// </summary>
        public int CityID { get; set; }
        /// <summary>
        /// park name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// park acreage
        /// </summary>
        public int Acreage { get; set; }
        /// <summary>
        /// park hours
        /// </summary>
        public string Hours { get; set; }
        /// <summary>
        /// park phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// park website
        /// </summary>
        public string Website { get; set; }
    }
}
