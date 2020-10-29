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
        /// Get All Cities
        /// </summary>
        /// <returns>Returns a list of all cities</returns>
        public IHttpActionResult Get()
        {
            CityService cityService = CreateCityService();
            var city = cityService.GetCities();
            return Ok(city);
        }
        /// <summary>
        /// Get City By ID
        /// </summary>
        /// <param name="id"> City ID</param>
        /// <returns>Returns city object by ID</returns>
        /// <returns>Returns city object by ID</returns>
        public IHttpActionResult Get(int id)
        {
            CityService CityService = CreateCityService();
            var city = CityService.GetCityByID(id);
            if (city.Name == null) return BadRequest("City ID not found");
            return Ok(city);
        }
        /// <summary>
        /// Create a new City
        /// </summary>
        /// <param name="city"> City Name</param>
        /// <returns>Returns A New City</returns>
        public IHttpActionResult Post(CityCreate city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cityService = CreateCityService();

            if (!cityService.CreateCities(city)) return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(CityEdit city, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateCityService();

            if (!service.UpdateCity(city, id)) return BadRequest("City ID not found.");
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
