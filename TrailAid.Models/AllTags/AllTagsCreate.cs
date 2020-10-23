using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.AllTags
{
    public class AllTagsCreate
    {
        [Required]
        public string ListOfAllTags { get; set; }
    }
}
