using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.Visited;

namespace TrailAid.Services
{
    public class VisitedService
    {
        private readonly Guid _userId;

        public VisitedService(Guid userId)
        {
            _userId = userId;
        }
        public string CreatePark(VisitedCreate model)
        {
            var entity = new Visited()
            {
                //TrailID = model.TrailID,
                //Name = model.Name,
                //Acreage = model.Acreage,
                //Hours = model.Hours,
                //PhoneNumber = model.PhoneNumber,
                //Website = model.Website
            };

            using (var ctx = new ApplicationDbContext())
            {
                int result = 0;

                try
                {
                    var city = ctx.Visits.Single(e => e.ID == model.TrailID);
                }
                catch
                {
                    if (entity.Trail == null) result += 1;
                }

                if (result == 1) return "Invalid Trail ID";

                try
                {
                    ctx.Visits.Add(entity);
                    ctx.SaveChanges();
                    return "Okay";
                }
                catch { }
                return "True";
            }
        }
        public IEnumerable<VisitedListItem> GetVisits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Visits.Select
                    (e => new VisitedListItem
                    {
                        //Name = e.Name,
                        TrailName = e.Trail.Name,
                        ID = e.ID
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
                return new VisitedDetail
                {
                    //Name = entity.Name,
                    //CityName = entity.City.Name,
                    //Acreage = entity.Acreage,
                    //Hours = entity.Hours,
                    //PhoneNumber = entity.PhoneNumber,
                    //Website = entity.Website
                };
            }
        }
        public string UpdateVisit(VisitedEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Visits.Single(e => e.ID == id);

                //entity.Name = model.Name;
                //entity.CityID = model.CityID;
                //entity.Acreage = model.Acreage;
                //entity.Hours = model.Hours;
                //entity.PhoneNumber = model.PhoneNumber;
                //entity.Website = model.Website;

                try
                {
                    ctx.Visits.Add(entity);
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
