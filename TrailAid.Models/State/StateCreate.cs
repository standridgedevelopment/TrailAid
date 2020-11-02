using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.State
{
    public class StateCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
