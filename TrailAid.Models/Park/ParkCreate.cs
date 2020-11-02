using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Park
{
    public class ParkCreate
    {
        [Required]
        public int CityID { get; set; }
        public string CityName { get; set; }
        [Required]
        public string Name { get; set; }
        public int Acreage { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}
