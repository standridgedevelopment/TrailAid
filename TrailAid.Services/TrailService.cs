using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.Trail;

namespace TrailAid.Services
{
    public class TrailService
    {
        private readonly Guid _userId;

        public TrailService(Guid userId)
        {
            _userId = userId;
        }
        private readonly int TagKey;

        public TrailService()
        {
            TagKey = 1;
        }
        public bool CreateTrail(TrailCreate model)
        {
            var entity = new Trail()
            {
                Name = model.Name,
                CityID = model.CityID,
                ParkID = model.ParkID,
                Rating = model.Rating,
                Difficulty = model.Difficulty,
                Description = model.Description,
                Distance = model.Distance,
                TypeOfTerrain = model.TypeOfTerrain,
                Tags = model.Tags,
                Elevation = model.Elevation,
                RouteType = model.RouteType
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TrailListItem> GetTrails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Trails.Select
                    (e => new TrailListItem
                    {
                        ID = e.ID,
                        Name = e.Name,
                        CityID = e.CityID,
                        CityName = e.City.Name,
                        ParkID = e.ParkID,
                        ParkName = e.Park.Name,
                    }
                    );
                return query.ToArray();
            }

        }
        public TrailDetail GetTrailByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Trails.Single(e => e.ID == id);
                if (entity.ParkID != null) return new TrailDetail
                {
                    Name = entity.Name,
                    CityID = entity.CityID,
                    CityName = entity.City.Name,
                    ParkID = entity.ParkID,
                    ParkName = entity.Park.Name,
                    Rating = entity.Rating,
                    Difficulty = entity.Difficulty,
                    Description = entity.Description,
                    Distance = entity.Distance,
                    TypeOfTerrain = entity.TypeOfTerrain,
                    Tags = entity.Tags,
                    Elevation = entity.Elevation,
                    RouteType = entity.RouteType,
                };
                else return new TrailDetail
                {
                    Name = entity.Name,
                    CityID = entity.CityID,
                    CityName = entity.City.Name,
                    Rating = entity.Rating,
                    Difficulty = entity.Difficulty,
                    Description = entity.Description,
                    Distance = entity.Distance,
                    TypeOfTerrain = entity.TypeOfTerrain,
                    Tags = entity.Tags,
                    Elevation = entity.Elevation,
                    RouteType = entity.RouteType,
                };
            }
        }
        public bool UpdateTrail(TrailEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Trails.Single(e => e.ID == id);

                entity.Name = model.Name;
                entity.CityID = model.CityID;
                entity.ParkID = model.ParkID;
                entity.Rating = model.Rating;
                entity.Difficulty = model.Difficulty;
                entity.Description = model.Description;
                entity.Distance = model.Distance;
                entity.TypeOfTerrain = model.TypeOfTerrain;
                entity.Tags = model.Tags;
                entity.Elevation = model.Elevation;
                entity.RouteType = model.RouteType;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTrail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Trails.Single(e => e.ID == id);

                ctx.Trails.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
