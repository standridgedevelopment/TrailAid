using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Data
{
    public class Park
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey (nameof(City))]
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public virtual List<Trail> Trails { get; set; } = new List<Trail>();
        public int Acreage { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        //public int AverageTrailRating { get; set; }
    }
}
