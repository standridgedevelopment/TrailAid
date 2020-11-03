using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.Visited
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class VisitedEdit
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// ID of the trail visited
        /// </summary>
        public int? TrailID { get; set; }
        /// <summary>
        /// Rating of the trail visited
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// Review of the trail visited
        /// </summary>
        public string Review { get; set; }
        /// <summary>
        /// true / false
        /// </summary>
        public bool AddToFavorites { get; set; }
    }
}
