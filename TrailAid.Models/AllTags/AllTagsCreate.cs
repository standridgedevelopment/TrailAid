using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.AllTags
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AllTagsCreate
    {
        [Required]
        public string ListOfAllTags { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
