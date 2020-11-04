using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Park
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ParkCreate
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// city id
        /// </summary>
        [Required]
        public int CityID { get; set; }
        /// <summary>
        /// city name
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// park name
        /// </summary>
        [Required]
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
