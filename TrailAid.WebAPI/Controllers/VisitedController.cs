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
            var user = VisitedService.GetVisits();
            return Ok(user);
        }
        public IHttpActionResult Get(int id)
        {
            VisitedService VisitedService = CreateVisitService();
            var user = VisitedService.GetVisitByID(id);
            return Ok(user);
        }
        public IHttpActionResult Post(VisitedCreate visited)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVisitService();

            result = service.CreateVisit(visited);
            if (result == "Invalid Trail ID") return BadRequest("Invalid Trail ID.");

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

            if (!service.DeleteVisit(id)) return InternalServerError();

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
