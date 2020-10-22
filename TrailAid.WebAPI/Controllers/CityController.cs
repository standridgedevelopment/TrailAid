using Microsoft.AspNet.Identity;
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
            var user = cityService.GetCities();
            return Ok(user);
        }
        public IHttpActionResult Get(int id)
        {
            CityService CityService = CreateCityService();
            var user = CityService.GetCityByID(id);
            return Ok(user);
        }
        public IHttpActionResult Post(CityCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCityService();

            if (!service.CreateCities(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(CityEdit user, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateCityService();

            if (!service.UpdateCity(user, id)) return InternalServerError();

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
            var cityService = new CityService(userID);
            return cityService;
        }
    }
}
