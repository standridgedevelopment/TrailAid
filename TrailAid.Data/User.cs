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
                        if (visit.Trail.ParkID != null)
                        {
                            var visitdetails = new VisitedDetail();
                            visitdetails.TrailID = visit.TrailID;
                            visitdetails.TrailName = visit.Trail.Name;
                            visitdetails.CityID = visit.Trail.CityID;
                            visitdetails.CityName = visit.Trail.City.Name;
                            visitdetails.ParkID = visit.Trail.ParkID;
                            visitdetails.ParkName = visit.Trail.Park.Name;
                            visitdetails.Rating = visit.Rating;
                            visitdetails.Review = visit.Review;
                            visitdetails.AddToFavorites = visit.AddToFavorites;
                            favorites.Add(visitdetails);
                        }
                        else
                        {
                            var visitdetails = new VisitedDetail();
                            visitdetails.TrailID = visit.TrailID;
                            visitdetails.TrailName = visit.Trail.Name;
                            visitdetails.CityID = visit.Trail.CityID;
                            visitdetails.CityName = visit.Trail.City.Name;
                            visitdetails.Rating = visit.Rating;
                            visitdetails.Review = visit.Review;
                            visitdetails.AddToFavorites = visit.AddToFavorites;
                            favorites.Add(visitdetails);
                        }
                    }
                }

                return favorites;
            }
            set { }
        }
        public virtual List<Visited> AllVisits { get; set; } = new List<Visited>();
    }
}
