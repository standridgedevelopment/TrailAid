using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Data
{
    public class Visited
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(User))]
        public Guid? UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey(nameof(Trail))]
        public int? TrailID { get; set; }
        public virtual Trail Trail { get; set; }
        public bool AddToFavorites { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
