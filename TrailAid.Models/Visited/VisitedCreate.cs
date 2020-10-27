using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
    public class VisitedCreate
    {
        public int? TrailID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
