using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("Description goes here")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public virtual List<VisitedFavorite> Favorites
        {
            get
            {
                List<VisitedFavorite> favorites = new List<VisitedFavorite>();
                foreach (var visit in AllVisits)
                {
                    if (visit.AddToFavorites == true)
                    {
                        var visitdetails = new VisitedFavorite
                        {
                            TrailID = visit.TrailID,
                            TrailName = visit.Trail.Name
                        };
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
