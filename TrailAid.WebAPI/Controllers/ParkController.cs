﻿using Microsoft.AspNet.Identity;
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
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParks();
            return Ok(user);
        }
        public IHttpActionResult GetByID(int id)
        {
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParkByID(id);
            return Ok(user);
        }
        public IHttpActionResult GetByName(string name)
        {
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParkByName(name);
            return Ok(user);
        }
        public IHttpActionResult GetByCityName(string cityName)
        {
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParkByCityName(cityName);
            return Ok(user);
        }
        public IHttpActionResult GetByAcreage(int acreage)
        {
            ParkService ParkService = CreateParkService();
            var user = ParkService.GetParkByAcreage(acreage);
            return Ok(user);
        }
        public IHttpActionResult Post(ParkCreate park)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateParkService();

            result = service.CreatePark(park);
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");

            return Ok();
        }
        public IHttpActionResult Put(ParkEdit park, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateParkService();

            result = service.UpdatePark(park, id);
            if (result == "Invalid City ID") return BadRequest("Invalid City ID.");

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
            var parkService = new ParkService(userID);
            return parkService;
        }
    }
}

