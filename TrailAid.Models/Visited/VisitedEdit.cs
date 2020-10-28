using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
    public class VisitedEdit
    {
        public int? TrailID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public bool AddToFavorites { get; set; }
    }
}
