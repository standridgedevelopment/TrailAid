using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Data
{
    public class AllTags
    {
        [Key]
        public int ID { get; set; }
        public string ListOfAllTags { get; set; }
    }
}
