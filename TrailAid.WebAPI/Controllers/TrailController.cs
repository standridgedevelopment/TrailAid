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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TrailController : ApiController
    {
        public string result = "";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        /// <summary>
        /// Get All Trails
        /// </summary>
        /// <returns>Returns a List of All Trails</returns>
        public IHttpActionResult Get()
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrails();
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By ID
        /// </summary>
        /// <param name="id"> trail id</param>
        /// <returns>Returns Trail Object by ID</returns>
        public IHttpActionResult GetById(int id)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByID(id);

            if (trail.Name == null) return BadRequest("Trail ID not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Name
        /// </summary>
        /// <param name="name"> trail name</param>
        /// <returns>Returns trail Object by Name</returns>
        public IHttpActionResult GetByName(string name)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByName(name);

            if (trail.Count == 0) return BadRequest("Trail name not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By City Name
        /// </summary>
        /// <param name="cityName"> city name</param>
        /// <returns>Returns trail Object by City Name</returns>
        public IHttpActionResult GetByCityName(string cityName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByCityName(cityName);

            if (trail.Count == 0) return BadRequest("City name not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By State Name
        /// </summary>
        /// <param name="stateName"> state name</param>
        /// <returns>Returns trail Object by City Name</returns>
        public IHttpActionResult GetByStateName(string stateName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByStateName(stateName);

            if (trail.Count == 0) return BadRequest("State Name Not Found.");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Park Name
        /// </summary>
        /// <param name="parkName"> park name</param>
        /// <returns>Returns trail Object by Park Name</returns>
        public IHttpActionResult GetByParkName(string parkName)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByParkName(parkName);

            if (trail.Count == 0) return BadRequest("Park name not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Rating
        /// </summary>
        /// <param name="rating"> trail rating</param>
        /// <returns>Returns trail Object by Rating</returns>
        public IHttpActionResult GetByRating(int rating)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByRating(rating);

            if (trail.Count == 0) return BadRequest("Rating not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Difficulty
        /// </summary>
        /// <param name="difficulty"> trail difficulty</param>
        /// <returns>Returns trail Object by Difficulty</returns>
        public IHttpActionResult GetByDifficulty(string difficulty)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDifficulty(difficulty);

            if (trail.Count == 0) return BadRequest("Difficulty not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Description
        /// </summary>
        /// <param name="description"> trail description</param>
        /// <returns>Returns trail Object by Description</returns>
        public IHttpActionResult GetByDescription(string description)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDescription(description);

            if (trail.Count == 0) return BadRequest("Description not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Distance
        /// </summary>
        /// <param name="distance"> trail distance</param>
        /// <returns>Returns trail Object by Distance</returns>
        public IHttpActionResult GetByDistance(int distance)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByDistance(distance);

            if (trail.Count == 0) return BadRequest("Distance not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Type Of Terrain
        /// </summary>
        /// <param name="typeOfTerrain"> terrain type</param>
        /// <returns>Returns trail Object by Type Of Terrain</returns>
        public IHttpActionResult GetByTypeOfTerrain(string typeOfTerrain)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByTypeOfTerrain(typeOfTerrain);

            if (trail.Count == 0) return BadRequest("Terrain Type not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Elevation
        /// </summary>
        /// <param name="elevation"> trail elevation</param>
        /// <returns>Returns trail Object by Elevation</returns>
        public IHttpActionResult GetByElevation(int elevation)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByElevation(elevation);

            if (trail.Count == 0) return BadRequest("Elevation not found");
            return Ok(trail);
        }
        /// <summary>
        /// Get Trail By Route Type
        /// </summary>
        /// <param name="routeType"> route type</param>
        /// <returns>Returns trail Object by Route Type</returns>
        public IHttpActionResult GetByRouteType(string routeType)
        {
            TrailService trailService = CreateTrailService();
            var trail = trailService.GetTrailByRouteType(routeType);

            if (trail.Count == 0) return BadRequest("Route Type not found");
            return Ok(trail);
        }
        /// <summary>
        /// Create a New Trail
        /// </summary>
        /// <returns>Returns A New Trail</returns>
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
        /// <summary> Update Trail </summary>
        /// <param name="id"> park id </param>
        /// <param name="trail"></param>
        /// <returns> Updates Trail Object </returns>
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
            if (result == "Update Error") return BadRequest("Invalid Trail ID.");
            return Ok();
        }
        /// <summary>
        /// Delete Trail
        /// </summary>
        /// <param name="id"> trail id</param>
        /// <returns>Deletes Trail Object</returns>
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
