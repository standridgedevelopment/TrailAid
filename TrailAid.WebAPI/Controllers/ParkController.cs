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
        public IHttpActionResult Get()
        {
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParks();
            return Ok(user);
        }
        public IHttpActionResult Get(int id)
        {
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParkByID(id);
            return Ok(user);
        }
        public IHttpActionResult Post(ParkCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateParkService();

            if (!service.CreatePark(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ParkEdit user, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateParkService();

            if (!service.UpdatePark(user, id)) return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateParkService();

            if (!service.DeletePark(id)) return InternalServerError();

            return Ok();
        }
        private ParkService CreateParkService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var cityService = new ParkService(userID);
            return cityService;
        }
    }
}

