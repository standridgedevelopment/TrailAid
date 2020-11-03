using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Models.Trail;

namespace TrailAid.Data
{
    public class Park
    {
        public string Name { get; set; }
        [Key]
        public int ID { get; set; }
        [ForeignKey (nameof(City))]
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public string CityName { get; set; }
        public virtual List<Trail> Trails { get; set; } = new List<Trail>();
        public List<TrailListInPark> TrailsInPark
        {
            get
            {
                List<TrailListInPark> newList = new List<TrailListInPark>();
                foreach (var trail in Trails)
                {
                    var trailInPark = new TrailListInPark()
                    {
                        ID = trail.ID,
                        Name = trail.Name,
                        Rating = trail.Rating
                    };
                    newList.Add(trailInPark);
                }
                return newList;
            }
            set { }
        }
        public int Acreage { get; set; }
        public string Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public double AverageTrailRating 
        {
            get
            {
                if (Trails.Count == 0 || Trails == null) return 0;
                double totalRating = 0;
                double totalReviews = 0;
                double averageRating = 0;
                foreach (var trail in Trails)
                {
                    totalRating += trail.Rating;
                    totalReviews += trail.Ratings.Count();
                }
                if(totalRating != 0 && totalReviews !=0)
                    averageRating = totalRating / totalReviews;
                return Math.Round((double)averageRating, 2);
            }
            set { }
        }
    }
}
