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
                try { var trail = ctx.Trails.Single(e => e.ID == model.TrailID); }
                catch { return "Invalid Trail ID"; }

                try { var user = ctx.Users.Single(e => e.ID == _userId); }
                catch { return "Invalid User ID"; }

                try { var visited = ctx.Visits.Single(e => e.TrailID == model.TrailID && e.UserID == _userId); }
                catch
                {
                    ctx.Visits.Add(entity);
                    ctx.SaveChanges();
                    return "Okay";
                }

                return "User Revisit";
            }
        }
        public IEnumerable<VisitedListItem> GetVisits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Visits.Where(e => e.UserID == _userId).Select
                    (e => new VisitedListItem
                    {
                        TrailID = e.TrailID,
                        TrailName = e.Trail.Name,
                        Rating = e.Rating
                    }
                     );
                return query.ToArray();
            }

        }
        public VisitedDetail GetVisitByTrailID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Visits.Single(e => e.TrailID == id && e.UserID == _userId);
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
                catch { }
                return new VisitedDetail();
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
                try
                {
                    var entity = ctx.Visits.Single(e => e.ID == id);

                    ctx.Visits.Remove(entity);
                }
                catch { return false; }
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
