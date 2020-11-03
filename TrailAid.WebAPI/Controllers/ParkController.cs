using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrailAid.Models.Park;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ParkController : ApiController
    {
        public string result = "";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        /// <summary>
        /// Get All Parks
        /// </summary>
        /// <returns>Returns a List of All Parks</returns>
        public IHttpActionResult Get()
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParks();
            return Ok(park);
        }
        /// <summary>
        /// Get Park By ID
        /// </summary>
        /// <param name="id"> park id</param>
        /// <returns>Returns Park Object by ID</returns>
        public IHttpActionResult GetByID(int id)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByID(id);

            if (park.Name == null) return BadRequest("Park ID not found");
            return Ok(park);
        }
        /// <summary>
        /// Get Park By Name
        /// </summary>
        /// <param name="name"> park name</param>
        /// <returns>Returns Park Object by Name</returns>
        public IHttpActionResult GetByName(string name)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByName(name);

            if (park.Count == 0) return BadRequest("Park Name not found");
            return Ok(park);
        }
        /// <summary>
        /// Get Park By City Name
        /// </summary>
        /// <param name="cityName"> city name</param>
        /// <returns>Returns Park Object by City Name</returns>
        public IHttpActionResult GetByCityName(string cityName)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByCityName(cityName);

            if (park.Count == 0) return BadRequest("City Name not found");
            return Ok(park);
        }
        /// <summary>
        /// Get Park By Acreage
        /// </summary>
        /// <param name="minacreage"> minimum acreage</param>
        /// <param name="maxacreage"> maximum acreage</param>
        /// <returns>Returns Park Object by Acreage</returns>
        public IHttpActionResult GetByAcreage(int minacreage, int maxacreage)
        {

            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByAcreage(minacreage, maxacreage);

            if (park.Count == 0) return BadRequest("Acreage not found");
            return Ok(park);
        }
        /// <summary>
        /// Create a New Park
        /// </summary>
        /// <returns>Returns A New Park</returns>
        public IHttpActionResult Post(ParkCreate park)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parkService = CreateParkService();

            result = parkService.CreatePark(park);
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");

            return Ok();
        }
        /// <summary> Update Park </summary>
        /// <param name="id"> park id </param>
        /// <param name="park"></param>
        /// <returns> Updates Park Object </returns>
        public IHttpActionResult Put(ParkEdit park, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parkService = CreateParkService();

            result = parkService.UpdatePark(park, id);
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");
            if (result == "Update Error") return BadRequest("Invalid Park ID.");
            return Ok();
        }
        /// <summary>
        /// Delete Park
        /// </summary>
        /// <param name="id"> park id</param>
        /// <returns>Deletes Park Object</returns>
        public IHttpActionResult Delete(int id)
        {
            var parkService = CreateParkService();

            if (!parkService.DeletePark(id)) return BadRequest("Park ID not found");
            return Ok();
        }
        private ParkService CreateParkService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var parkService = new ParkService();
            return parkService;
        }
    }
}

