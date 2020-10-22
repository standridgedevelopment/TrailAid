using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.Park;

namespace TrailAid.Services
{
    public class ParkService
    {
        private readonly Guid _userId;

        public ParkService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePark(ParkCreate model)
        {
            var entity = new Park()
            {
                CityID = model.CityID,
                Name = model.Name,
                Acreage = model.Acreage,
                Hours = model.Hours,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ParkListItem> GetParks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Parks.Select
                    (e => new ParkListItem
                    {
                        Name = e.Name,
                        CityName = e.City.Name,
                        ID = e.ID
                    }
                    );
                return query.ToArray();
            }

        }
        public ParkDetail GetParkByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parks.Single(e => e.ID == id);
                return new ParkDetail
                {
                    Name = entity.Name,
                    CityName = entity.City.Name,
                    Acreage = entity.Acreage,
                    Hours = entity.Hours,
                    PhoneNumber = entity.PhoneNumber,
                    Website = entity.Website
                };
            }
        }
        public bool UpdatePark(ParkEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parks.Single(e => e.ID == id);

                entity.Name = model.Name;
                entity.CityID = model.CityID;
                entity.Acreage = model.Acreage;
                entity.Hours = model.Hours;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Website = model.Website;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePark(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parks.Single(e =>e.ID == id);

                ctx.Parks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
