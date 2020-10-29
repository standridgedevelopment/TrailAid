using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrailAid.Models.Trail;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
    public class TrailController : ApiController
    {
        public string result = "";
        public IHttpActionResult Get()
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrails();
            return Ok(trail);
        }
        public IHttpActionResult GetById(int id)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByID(id);
            return Ok(trail);
        }
        public IHttpActionResult GetByName(string name)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByName(name);
            return Ok(trail);
        }
        public IHttpActionResult GetByCityName(string cityName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByCityName(cityName);
            return Ok(trail);
        }
        public IHttpActionResult GetByParkName(string parkName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByParkName(parkName);
            return Ok(trail);
        }
        public IHttpActionResult GetByRating(int rating)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByRating(rating);
            return Ok(trail);
        }
        public IHttpActionResult GetByDifficulty(string difficulty)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDifficulty(difficulty);
            return Ok(trail);
        }
        public IHttpActionResult GetByDescription(string description)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDescription(description);
            return Ok(trail);
        }
        public IHttpActionResult GetByDistance(int distance)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDistance(distance);
            return Ok(trail);
        }
        public IHttpActionResult GetByTypeOfTerrain(string typeOfTerrain)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByTypeOfTerrain(typeOfTerrain);
            return Ok(trail);
        }
        public IHttpActionResult GetByElevation(int elevation)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByElevation(elevation);
            return Ok(trail);
        }
        public IHttpActionResult GetByRouteType(string routeType)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByRouteType(routeType);
            return Ok(trail);
        }
        public IHttpActionResult Post(TrailCreate trail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trailService = CreateTrailService();

            result = trailService.CreateTrail(trail);
            if (result == "Tag Error") return BadRequest("Tag Not Found.");
            if (result == "Invalid City ID & Park ID") return BadRequest("Invalid City ID & Park ID.");
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");
            if (result == "Invalid Park ID") return BadRequest("Invalid Park ID.");

            return Ok();
        }
        public IHttpActionResult Put(TrailEdit trail, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var trailService = CreateTrailService();
            result = trailService.UpdateTrail(trail, id);
            if (result == "Tag Error") return BadRequest("Tag Not Found.");
            if (result == "Tag Already Exists") return BadRequest("Tag Already Exists.");
            if (result == "Tag not found") return BadRequest("Tag Not Found.");
            if (result == "Invalid City ID & Park ID") return BadRequest("Invalid City ID & Park ID.");
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");
            if (result == "Invalid Park ID") return BadRequest("Invalid Park ID.");

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var trailService = CreateTrailService();

            if (!trailService.DeleteTrail(id)) return InternalServerError();

            return Ok();
        }

        private TrailService CreateTrailService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var trailService = new TrailService();
            return trailService;
        }
    }
}
