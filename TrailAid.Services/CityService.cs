﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.City;
using static TrailAid.Data.ApplicationUser;

namespace TrailAid.Services
{
    public class CityService
    {
        public bool CreateCities(CityCreate model)
        {
            var entity = new City()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cities.Add(entity);
                //var testing = ctx.SaveChanges();
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CityListItem> GetCities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Cities.Select
                    (e => new CityListItem
                    {
                        Name = e.Name,
                        ID = e.ID
                    }
                    );
                return query.ToArray();
            }

        }
        public CityDetail GetCityByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Cities.Single(e => e.ID == id);
                    return new CityDetail
                    {
                        Name = entity.Name
                    };
                }
                catch {}
                return new CityDetail();
            }
        }
        public bool UpdateCity(CityEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                var entity = ctx.Cities.Single(e => e.ID == id);

                entity.Name = model.Name;
                }
                catch { return false; }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCity(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                var entity = ctx.Cities.Single(e => e.ID == id);

                ctx.Cities.Remove(entity);
                }
                catch { return false; }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
