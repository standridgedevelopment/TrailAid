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
        public string CreateTrail(TrailCreate model)
        {
            var entity = new Trail()
            {
                TagsID = 1,
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

            if (model.Tags != null)
            {
                entity.Tags = $"{model.Tags} ";
                foreach (var tag in entity.Tags.Split(' '))
                {
                    if (!entity.AllTags.ListOfAllTags.Contains(tag))
                    {
                        return "Tag Error";
                    }
                }
            }

            using (var ctx = new ApplicationDbContext())
            {
                int result = 0;
                try
                {
                    ctx.Trails.Add(entity);
                    ctx.SaveChanges();
                    return "Okay";
                }
                catch { }

                try
                {
                    var park = ctx.Parks.Single(e => e.ID == model.ParkID);
                }
                catch
                {
                    if (entity.Park == null) result += 1;
                }

                try
                {
                    var city = ctx.Cities.Single(e => e.ID == model.CityID);
                }
                catch
                {
                    if (entity.City == null) result += 2;
                }

                if (result == 1) return "Invalid Park ID";
                if (result == 2) return "Invalid City ID";
                if (result == 3) return "Invalid City ID & Park ID";

                return "True";
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
        public string UpdateTrail(TrailEdit model, int id)
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
                entity.Elevation = model.Elevation;
                entity.RouteType = model.RouteType;

                if (model.Tags != null)
                {
                    foreach (var tag in entity.Tags.Split(' '))
                    {
                        if (!entity.AllTags.ListOfAllTags.Contains(tag))
                        {
                            return "Tag Error";
                        }
                        else if (entity.Tags.Contains(model.Tags))
                        {
                            entity.Tags = entity.Tags;
                            return "Tag Already Exists";
                        }
                        else
                        {
                            entity.Tags = $"{entity.Tags} " + model.Tags;
                        }
                    }
                }
                else { entity.Tags = model.Tags; }

                try
                {
                    ctx.Trails.Add(entity);
                    ctx.SaveChanges();
                    return "Okay";
                }
                catch
                {
                    if (entity.City == null && entity.Park == null && entity.ParkID != null) return "Invalid City ID & Park ID";
                    if (entity.City == null) return "Invalid City ID";
                    if (entity.Park == null) return "Invalid Park ID";

                    return "True";
                }
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
