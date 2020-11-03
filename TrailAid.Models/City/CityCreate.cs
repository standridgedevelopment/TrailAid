using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.City
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CityCreate
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary> city name </summary>
        [Required]
        public string Name { get; set; }
        public int? StateID { get; set; }
    }
}
