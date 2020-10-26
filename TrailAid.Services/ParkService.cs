﻿using System;
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
        public string CreatePark(ParkCreate model)
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
                int result = 0;
                try
                {
                    ctx.Parks.Add(entity);
                    ctx.SaveChanges();
                    return "Okay";
                }
                catch { }

                try
                {
                    var city = ctx.Cities.Single(e => e.ID == model.CityID);
                }
                catch
                {
                    if (entity.City == null) result += 1;
                }

                if (result == 1) return "Invalid City ID";

                return "True";
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
        public string UpdatePark(ParkEdit model, int id)
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

                try
                {
                    ctx.Parks.Add(entity);
                    ctx.SaveChanges();
                    return "Okay";
                }
                catch
                {
                    if (entity.City == null) return "Invalid City ID";

                    return "True";
                }
            }
        }
        public bool DeletePark(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parks.Single(e => e.ID == id);

                ctx.Parks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
