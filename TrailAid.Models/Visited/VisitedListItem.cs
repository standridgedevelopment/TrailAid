using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class VisitedListItem
    {
        public int? TrailID { get; set; }
        public string TrailName { get; set; }
        public int Rating { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
