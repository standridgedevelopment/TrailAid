using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
    public class VisitedCreate
    {
        [Required]
        public int? TrailID { get; set; }
        [Required]
        [Range (0,5)]
        public int Rating { get; set; }
        public string Review { get; set; }
        public bool AddToFavorites { get; set; }
    }
}
