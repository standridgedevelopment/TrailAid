using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.Visited;
using static TrailAid.Data.ApplicationUser;

namespace TrailAid.Services
{
    public class VisitedService
    {
        private readonly Guid _userId;

        public VisitedService(Guid userId)
        {
            _userId = userId;
        }
        public string CreateVisit(VisitedCreate model)
        {
            var entity = new Visited()
            {
                UserID = _userId,
                TrailID = model.TrailID,
                Rating = model.Rating,
                Review = model.Review,
                AddToFavorites = model.AddToFavorites
        };

            using (var ctx = new ApplicationDbContext())
            {
                int result = 0;
                int visitResult = 0;

                try{var trail = ctx.Trails.Single(e => e.ID == model.TrailID);}
                catch{result += 1;}
                if (result == 1) return "Invalid Trail ID";

                try { var visited = ctx.Visits.Single(e => e.TrailID == model.TrailID && e.UserID == _userId); }
                catch { visitResult += 1; }
                if (visitResult != 1) return "User Revisit";

                ctx.Visits.Add(entity);
                ctx.SaveChanges();
                return "Okay";
            }
        }
        public IEnumerable<VisitedListItem> GetVisits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Visits.Select
                    (e => new VisitedListItem
                    {
                        ID = e.ID,
                        TrailID =e.TrailID,
                        TrailName = e.Trail.Name,
                        Rating = e.Rating
                    }
                    );
                return query.ToArray();
            }

        }
        public VisitedDetail GetVisitByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.Single(e => e.ID == id);
                if (entity.Trail.ParkID != null) return new VisitedDetail
                {
                    TrailID = entity.TrailID,
                    TrailName = entity.Trail.Name,
                    ParkID = entity.Trail.Park.ID,
                    ParkName = entity.Trail.Park.Name,
                    CityID = entity.Trail.City.ID,
                    CityName = entity.Trail.City.Name,
                    Rating = entity.Rating,
                    Review = entity.Review,
                    AddToFavorites = entity.AddToFavorites
                };
                else return new VisitedDetail
                {
                    TrailID = entity.TrailID,
                    TrailName = entity.Trail.Name,
                    CityID = entity.Trail.City.ID,
                    CityName = entity.Trail.City.Name,
                    Rating = entity.Rating,
                    Review = entity.Review,
                    AddToFavorites = entity.AddToFavorites
                };
            }
        }
        public string UpdateVisit(VisitedEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.Single(e => e.ID == id);
                entity.TrailID = model.TrailID;
                entity.Rating = model.Rating;
                entity.Review = model.Review;
                entity.AddToFavorites = model.AddToFavorites;
                try
                {
                    ctx.SaveChanges();
                    return "Okay";
                }
                catch
                {
                    if (entity.Trail == null) return "Invalid Trail ID";

                    return "True";
                }
            }
        }
        public bool DeleteVisit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.Single(e => e.ID == id);

                ctx.Visits.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
