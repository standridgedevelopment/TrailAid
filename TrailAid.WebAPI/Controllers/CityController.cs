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
        /// <summary>  
        /// Get all Cities  
        /// </summary>  
        /// <returns>List of Cities</returns>
        public IHttpActionResult Get()
        {
            CityService cityService = CreateCityService();
            var user = cityService.GetCities();
            return Ok(user);
        }
        /// <summary>  
        /// Get City By ID  
        /// </summary>  
        /// <param name="id"> city id</param>  
        /// <returns>city object by id </returns>
        public IHttpActionResult Get(int id)
        {
            CityService CityService = CreateCityService();
            var city = CityService.GetCityByID(id);
            if (city.Name == null) return BadRequest("City ID not found");
            return Ok(city);
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

            if (!service.UpdateCity(user, id)) return BadRequest("City ID not found.");

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCityService();

            if (!service.DeleteCity(id)) return BadRequest("City ID not found.");

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
