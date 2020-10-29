﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrailAid.Models.City;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
    public class CityController : ApiController
    {
        public IHttpActionResult Get()
        {
            CityService cityService = CreateCityService();
            var city = cityService.GetCities();
            return Ok(city);
        }
        public IHttpActionResult Get(int id)
        {
            CityService cityService = CreateCityService();
            var city = cityService.GetCityByID(id);
            if (city.Name == null) return BadRequest("ID not found");
            return Ok(city);
        }
        public IHttpActionResult Post(CityCreate city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCityService();

            if (!service.CreateCities(city))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(CityEdit city, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateCityService();

            if (!service.UpdateCity(city, id)) return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCityService();

            if (!service.DeleteCity(id)) return InternalServerError();

            return Ok();
        }
        private CityService CreateCityService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var cityService = new CityService();
            return cityService;
        }
    }
}
