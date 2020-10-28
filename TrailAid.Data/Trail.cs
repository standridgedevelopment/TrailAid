﻿using System;
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

        [ForeignKey(nameof(City))]
        public int? CityID { get; set; }
        public virtual City City { get; set; }

        [ForeignKey(nameof(Park))]
        public int? ParkID { get; set; }
        public virtual Park Park { get; set; }

        [ForeignKey(nameof(AllTags))]
        public int TagsID{ get; set; }
        public virtual AllTags AllTags { get; set; }

        public double Rating
        {
            get
            {
                if (Ratings.Count == 0 || Ratings == null) return 0;
                double totalRating = 0;
                double averageRating = 0;
                foreach (var rating in Ratings)
                {
                    totalRating += rating.Rating;
                }
                averageRating = totalRating / Ratings.Count();
                return Math.Round((double)averageRating, 2);
            }
            set { }
        }
        public string Difficulty { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public string TypeOfTerrain { get; set; }
        public string Tags { get; set; }
        public int Elevation { get; set; }
        public string RouteType { get; set; }
        public virtual List<Visited> Ratings { get; set; } = new List<Visited>();
    }
}
