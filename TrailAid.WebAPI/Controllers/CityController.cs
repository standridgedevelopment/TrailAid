using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TrailAid.Models.City;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CityController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Get All Cities
        /// </summary>
        /// <returns>Returns a List of All Cities</returns>
        public IHttpActionResult Get()
        {
            CityService cityService = CreateCityService();
            var city = cityService.GetCities();
            return Ok(city);
        }
        /// <summary>
        /// Get City By ID
        /// </summary>
        /// <param name="id"> city id</param>
        /// <returns>Returns City Object by ID</returns>
        public IHttpActionResult Get(int id)
        {
            CityService CityService = CreateCityService();
            var city = CityService.GetCityByID(id);
            if (city.Name == null) return BadRequest("City ID not found");
            return Ok(city);
        }
        /// <summary>
        /// Create a New City
        /// </summary>
        /// <returns>Returns A New City</returns>
        public IHttpActionResult Post(CityCreate city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cityService = CreateCityService();

            if (!cityService.CreateCities(city)) return InternalServerError();

            return Ok();
        }
        /// <summary> Update City </summary>
        /// <param name="id"> city id </param>
        /// <param name="city"></param>
        /// <returns> Updates City Object </returns>
        public IHttpActionResult Put(CityEdit city, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateCityService();

            if (!service.UpdateCity(city, id)) return BadRequest("City ID not found.");
            return Ok();
        }
        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="id"> city id</param>
        /// <returns>Deletes City Object</returns>
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
