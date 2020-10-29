using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
    public class VisitedFavorite
    {
        [Key]
        public int VisitID { get; set; }
        public int? TrailID { get; set; }
        public string TrailName { get; set; }
    }
}
