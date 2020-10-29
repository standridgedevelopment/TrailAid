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
    public class VisitedController : ApiController
    {
        public string result = "";
        public IHttpActionResult Get()
        {
            VisitedService VisitedService = CreateVisitService();
            var visit = VisitedService.GetVisits();
            return Ok(visit);
        }
        public IHttpActionResult Get(int id)
        {
            VisitedService VisitedService = CreateVisitService();
            var visit = VisitedService.GetVisitByTrailID(id);
            if (visit.TrailID == null) return BadRequest("Trail ID not found");
            return Ok(visit);
        }
        public IHttpActionResult Post(VisitedCreate visited)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateVisitService();
            result = service.CreateVisit(visited);
            if (result == "Invalid Trail ID") return BadRequest("Invalid Trail ID.");
            if (result == "Invalid User ID") return BadRequest("Invalid User ID.");
            if (result == "User Revisit") return BadRequest("User has already Visited this Trail.");
            return Ok();
        }
        public IHttpActionResult Put(VisitedEdit visited, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateVisitService();
            result = service.UpdateVisit(visited, id);
            if (result == "Invalid Trial ID") return BadRequest("Invalid Trail ID.");
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVisitService();
            if (!service.DeleteVisit(id)) return BadRequest("Trail ID not found");
            return Ok();
        }
        private VisitedService CreateVisitService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var visitService = new VisitedService(userID);
            return visitService;
        }
    }
}
