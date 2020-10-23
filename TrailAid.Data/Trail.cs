using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Data
{
    public class Trail
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey(nameof(CityID))]
        public int CityID;
        [ForeignKey(nameof(ParkID))]
        [Required]
        public int ParkID;
        public virtual City City { get; set; }
        public virtual Park Park { get; set; }
        public int Rating { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public string TypeOftTerrain { get; set; }
        public string Tags { get; set; }
        public List<string> listOfAllPossibleTags { get; set; }
        public int Elevation { get; set; }
        public string RouteType { get; set; }
    }
}
