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
            TrailService TrailService = CreateTrailService();
            var user = TrailService.GetTrails();
            return Ok(user);
        }
        public IHttpActionResult GetById(int id)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByID(id);
            if (trail.Name == null) return BadRequest("Trail ID not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByName(string name)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByName(name);
            if (trail.Count == 0) return BadRequest("Trail name not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByCityName(string cityName)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByCityName(cityName);
            if (trail.Count == 0) return BadRequest("City name not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByParkName(string parkName)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByParkName(parkName);
            if (trail.Count == 0) return BadRequest("Park name not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByRating(int rating)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByRating(rating);
            if (trail.Count == 0) return BadRequest("Rating not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByDifficulty(string difficulty)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByDifficulty(difficulty);
            if (trail.Count == 0) return BadRequest("Difficulty not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByDescription(string description)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByDescription(description);
            if (trail.Count == 0) return BadRequest("Description not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByDistance(int distance)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByDistance(distance);
            if (trail.Count == 0) return BadRequest("Distance not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByTypeOfTerrain(string typeOfTerrain)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByTypeOfTerrain(typeOfTerrain);
            if (trail.Count == 0) return BadRequest("Terrain Type not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByElevation(int elevation)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByElevation(elevation);
            if (trail.Count == 0) return BadRequest("Elevation not found");
            return Ok(trail);
        }
        public IHttpActionResult GetByRouteType(string routeType)
        {
            TrailService TrailService = CreateTrailService();
            var trail = TrailService.GetTrailByRouteType(routeType);
            if (trail.Count == 0) return BadRequest("Route Type not found");
            return Ok(trail);
        }
        public IHttpActionResult Post(TrailCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTrailService();

            result = service.CreateTrail(user);
            if (result == "Tag Error") return BadRequest("Tag Not Found.");
            if (result == "Invalid City ID & Park ID") return BadRequest("Invalid City ID & Park ID.");
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");
            if (result == "Invalid Park ID") return BadRequest("Invalid Park ID.");

            return Ok();
        }
        public IHttpActionResult Put(TrailEdit trail, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateTrailService();
            result = service.UpdateTrail(trail, id);
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
            var service = CreateTrailService();

            if (!service.DeleteTrail(id)) return BadRequest("Trail ID not found");

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
