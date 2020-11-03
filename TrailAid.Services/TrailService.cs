using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.Trail;
using static TrailAid.Data.ApplicationUser;

namespace TrailAid.Services
{
    public class TrailService
    {
        readonly List<TrailDetail> searchResults = new List<TrailDetail>();

        public string CreateTrail(TrailCreate model)
        {
            var entity = new Trail()
            {
                TagsID = 1,
                Name = model.Name,
                CityID = model.CityID,
                ParkID = model.ParkID,
                Difficulty = model.Difficulty,
                Description = model.Description,
                Distance = model.Distance,
                TypeOfTerrain = model.TypeOfTerrain,
                Tags = model.AddTags,
                Elevation = model.Elevation,
                RouteType = model.RouteType
            };

            using (var ctx = new ApplicationDbContext())
            {
                if (model.AddTags != null)
                {
                    if (entity.Tags == null) entity.Tags = "";
                    foreach (var tag in model.AddTags.Split(' '))
                    {
                        if (entity.AllTags != null && !entity.AllTags.ListOfAllTags.Contains(tag))
                        {
                            return "Tag Error";
                        }
                        else if (!entity.Tags.Contains(tag))
                        {
                            entity.Tags += $"{tag} ";
                        }
                        
                    }
                }
                int result = 0;

                try { var park = ctx.Parks.Single(e => e.ID == model.ParkID); }
                catch { if (entity.ParkID != null && entity.Park == null) result += 1; }

                try { var city = ctx.Cities.Single(e => e.ID == model.CityID); }
                catch { if (entity.City == null) result += 2; }

                if (result == 1) return "Invalid Park ID";
                if (result == 2) return "Invalid City ID";
                if (result == 3) return "Invalid City ID & Park ID";

                ctx.Trails.Add(entity);
                ctx.SaveChanges();
                return "Okay";
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
                        StateID = e.City.StateID,
                        StateName = e.City.State.Name,
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
                try
                {
                    var entity = ctx.Trails.Single(e => e.ID == id);
                    if (entity.ParkID != null) return new TrailDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        CityID = entity.CityID,
                        CityName = entity.City.Name,
                        StateID = entity.City.StateID,
                        StateName = entity.City.State.Name,
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
                        ID = entity.ID,
                        Name = entity.Name,
                        CityID = entity.CityID,
                        CityName = entity.City.Name,
                        StateID = entity.City.StateID,
                        StateName = entity.City.State.Name,
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
                }
                catch { }
                return new TrailDetail();
            }
        }
        public List<TrailDetail> GetTrailByCity(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.ID == id).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Name.Contains(name)).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByCityName(string cityName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.City.Name.Contains(cityName)).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByParkName(string parkName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Park.Name == parkName).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByRating(int rating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Rating == rating).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByDifficulty(string difficulty)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Difficulty == difficulty).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByDescription(string description)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Description == description).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByDistance(int distance)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Distance == distance).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByTypeOfTerrain(string typeOfTerrain)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.TypeOfTerrain == typeOfTerrain).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByElevation(int elevation)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.Elevation == elevation).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public List<TrailDetail> GetTrailByRouteType(string routeType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var trails = ctx.Trails.Where(e => e.RouteType == routeType).ToList();
                foreach (var trail in trails)
                {
                    if (trail.ParkID != null)
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                    else
                    {
                        var foundTrail = new TrailDetail
                        {
                            ID = trail.ID,
                            Name = trail.Name,
                            CityID = trail.CityID,
                            CityName = trail.City.Name,
                            StateID = trail.City.StateID,
                            StateName = trail.City.State.Name,
                            ParkID = trail.ParkID,
                            ParkName = trail.Park.Name,
                            Rating = trail.Rating,
                            Difficulty = trail.Difficulty,
                            Description = trail.Description,
                            Distance = trail.Distance,
                            TypeOfTerrain = trail.TypeOfTerrain,
                            Tags = trail.Tags,
                            Elevation = trail.Elevation,
                            RouteType = trail.RouteType,
                        };
                        searchResults.Add(foundTrail);
                    }
                }
                return searchResults;
            }
        }
        public string UpdateTrail(TrailEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Trails.Single(e => e.ID == id);

                    if (model.Name != null) entity.Name = model.Name;
                    if (model.CityID != null) entity.CityID = model.CityID;
                    if (model.ParkID != null) entity.ParkID = model.ParkID;
                    if (model.Difficulty != null) entity.Difficulty = model.Difficulty;
                    if (model.Description != null) entity.Description = model.Description;
                    if (model.Distance != 0) entity.Distance = model.Distance;
                    if (model.TypeOfTerrain != null) entity.TypeOfTerrain = model.TypeOfTerrain;
                    if (model.Elevation != 0) entity.Elevation = model.Elevation;
                    if (model.RouteType != null) entity.RouteType = model.RouteType;
                    if (model.AddTags != null)
                    {
                        if (entity.Tags == null) entity.Tags = "";
                        foreach (var tag in model.AddTags.Split(' '))
                        {
                            if (entity.AllTags != null && !entity.AllTags.ListOfAllTags.Contains(tag))
                            {
                                return "Tag Error";
                            }
                            else if (entity.Tags.Contains(tag))
                            {
                                entity.Tags = entity.Tags;
                                return "Tag Already Exists";
                            }
                            entity.Tags += $"{tag} ";
                        }
                    }
                    if (model.DeleteTags != null)
                    {
                        foreach (var tag in model.DeleteTags.Split(' '))
                        {
                            int firstCount = entity.Tags.Count();
                            string delete = entity.Tags.Replace($"{tag}", "");
                            entity.Tags = delete.Replace("  ", " ");
                            if (entity.Tags.Count() < firstCount) { }
                            else return "Tag not found";
                        }
                    }
                    try
                    {
                        ctx.SaveChanges();
                        return "Okay";
                    }
                    catch
                    {
                        if (entity.City == null && entity.Park == null && entity.ParkID != null) return "Invalid City ID & Park ID";
                        if (entity.City == null) return "Invalid City ID";
                        if (entity.Park == null && model.ParkID != null) return "Invalid Park ID";
                    }
                }
                catch { }
                return "Update Error";
            }
        }
        public bool DeleteTrail(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Trails.Single(e => e.ID == id);

                    ctx.Trails.Remove(entity);
                }
                catch { return false; }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
