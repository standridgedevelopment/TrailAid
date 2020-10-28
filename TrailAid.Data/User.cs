using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Models.Visited;

namespace TrailAid.Data
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public virtual List<VisitedDetail> Favorites
        {
            get
            {
                List<VisitedDetail> favorites = new List<VisitedDetail>();
                foreach (var visit in AllVisits)
                {
                    if (visit.AddToFavorites == true)
                    {
                        var visitdetails = new VisitedDetail();
                        visitdetails.TrailID = visit.TrailID;
                        visitdetails.TrailName = visit.Trail.Name;
                        favorites.Add(visitdetails);
                    }
                }

                return favorites;
            }
            set { }
        }
        public virtual List<Visited> AllVisits { get; set; } = new List<Visited>();
    }
}
