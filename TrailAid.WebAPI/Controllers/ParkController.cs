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
    public class ParkController : ApiController
    {
        public string result = "";
        public IHttpActionResult Get()
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParks();
            return Ok(park);
        }
        public IHttpActionResult GetByID(int id)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByID(id);

            if (park.Name == null) return BadRequest("Park ID not found");
            return Ok(park);
        }
        public IHttpActionResult GetByName(string name)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByName(name);

            if (park.Count == 0) return BadRequest("Park Name not found");
            return Ok(park);
        }
        public IHttpActionResult GetByCityName(string cityName)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByCityName(cityName);

            if (park.Count == 0) return BadRequest("City Name not found");
            return Ok(park);
        }
        public IHttpActionResult GetByAcreage(int minacreage, int maxacreage)
        {

            ParkService parkService = CreateParkService();
            var park = parkService.GetParkByAcreage(minacreage, maxacreage);

            if (park.Count == 0) return BadRequest("Acreage not found");
            return Ok(park);
        }
        public IHttpActionResult Post(ParkCreate park)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parkService = CreateParkService();

            result = parkService.CreatePark(park);
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");

            return Ok();
        }
        public IHttpActionResult Put(ParkEdit park, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parkService = CreateParkService();

            result = parkService.UpdatePark(park, id);
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");

            return Ok();
        }
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

