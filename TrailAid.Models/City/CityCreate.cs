using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.City
{
    public class CityCreate
    {
        [Required]
        public string Name { get; set; }
        public int? StateID { get; set; }
    }
}
