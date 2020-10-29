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

            if (trail.Name == null) return BadRequest("Trail ID not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByName(string name)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByName(name);

            if (trail.Count == 0) return BadRequest("Trail name not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByCityName(string cityName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByCityName(cityName);

            if (trail.Count == 0) return BadRequest("City name not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByParkName(string parkName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByParkName(parkName);

            if (trail.Count == 0) return BadRequest("Park name not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByRating(int rating)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByRating(rating);

            if (trail.Count == 0) return BadRequest("Rating not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByDifficulty(string difficulty)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDifficulty(difficulty);

            if (trail.Count == 0) return BadRequest("Difficulty not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByDescription(string description)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDescription(description);

            if (trail.Count == 0) return BadRequest("Description not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByDistance(int distance)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDistance(distance);

            if (trail.Count == 0) return BadRequest("Distance not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByTypeOfTerrain(string typeOfTerrain)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByTypeOfTerrain(typeOfTerrain);

            if (trail.Count == 0) return BadRequest("Terrain Type not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByElevation(int elevation)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByElevation(elevation);

            if (trail.Count == 0) return BadRequest("Elevation not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByRouteType(string routeType)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByRouteType(routeType);

            if (trail.Count == 0) return BadRequest("Route Type not found");
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

            if (!trailService.DeleteTrail(id)) return BadRequest("Trail ID not found");
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
