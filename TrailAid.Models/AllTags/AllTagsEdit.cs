using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.AllTags
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AllTagsEdit
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Adds Tags to list
        /// </summary>
        public string AddTags { get; set; }
        /// <summary>
        /// Removes Tags from list
        /// </summary>
        public string DeleteTags { get; set; }
        /// <summary>
        /// Updates all tags
        /// </summary>
        public string ListOfAllTags { get; set; }
    }
}
