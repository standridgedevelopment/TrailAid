using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrailAid.Models.Visited;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class VisitedController : ApiController
    {
        public string result = "";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        /// <summary>
        /// Get All Visits
        /// </summary>
        /// <returns>Returns a List of All Visits</returns>
        public IHttpActionResult Get()
        {
            VisitedService visitedService = CreateVisitService();
            var visit = visitedService.GetVisits();
            return Ok(visit);
        }
        /// <summary>
        /// Get Visit By ID
        /// </summary>
        /// <param name="id"> visit id</param>
        /// <returns>Returns Visit Object by ID</returns>
        public IHttpActionResult Get(int id)
        {
            VisitedService visitedService = CreateVisitService();
            var visit = visitedService.GetVisitByTrailID(id);

            if (visit.TrailID == null) return BadRequest("Trail ID not found");
            return Ok(visit);
        }
        /// <summary>
        /// Create a New Visit
        /// </summary>
        /// <returns>Returns A New Visit</returns>
        public IHttpActionResult Post(VisitedCreate visited)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var visitedService = CreateVisitService();
            result = visitedService.CreateVisit(visited);
            if (result == "Invalid Trail ID") return BadRequest("Invalid Trail ID.");
            if (result == "Invalid User ID") return BadRequest("Invalid User ID.");
            if (result == "User Revisit") return BadRequest("User has already Visited this Trail.");
            return Ok();
        }
        /// <summary> Update Visit </summary>
        /// <param name="id"> visit id </param>
        /// <param name="visited"></param>
        /// <returns> Updates Visit Object </returns>
        public IHttpActionResult Put(VisitedEdit visited, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var visitedService = CreateVisitService();
            result = visitedService.UpdateVisit(visited, id);
            if (result == "Invalid Trail ID") return BadRequest("Invalid Trail ID. Trail not found");
            if (result == "Update Error") return BadRequest("Invalid Trail ID. You have not visited that Trail.");
            return Ok();
        }
        /// <summary>
        /// Delete Visit
        /// </summary>
        /// <param name="id"> visit id</param>
        /// <returns>Deletes Visit Object</returns>
        public IHttpActionResult Delete(int id)
        {
            var visitedService = CreateVisitService();

            if (!visitedService.DeleteVisit(id)) return BadRequest("Trail ID not found");
            return Ok();
        }
        private VisitedService CreateVisitService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var visitedService = new VisitedService(userID);
            return visitedService;
        }
    }
}
