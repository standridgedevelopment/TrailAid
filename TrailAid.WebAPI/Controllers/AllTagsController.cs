using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrailAid.Models.AllTags;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
    public class AllTagsController : ApiController
    {
        public string result = "";
        public IHttpActionResult Get()
        {
            AllTagsService allTagsService = CreateAllTagsService();
            var tags = allTagsService.GetAllTags();
            return Ok(tags);
        }
        public IHttpActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allTagsService = CreateAllTagsService();

            if (!allTagsService.CreateAllTags())
                return BadRequest("List of tags already exists");

            return Ok();
        }
        public IHttpActionResult Put(AllTagsEdit tags)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var allTagsService = CreateAllTagsService();

            result = allTagsService.UpdateAllTags(tags);
            if (result == "Tag Already Exists") return BadRequest("Tag Already Exists.");
            if (result == "Tag not found") return BadRequest("Tag Not Found.");

            return Ok();
        }
        private AllTagsService CreateAllTagsService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var allTagsService = new AllTagsService();
            return allTagsService;
        }
    }
}
