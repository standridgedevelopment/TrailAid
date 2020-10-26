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
        public IHttpActionResult Get()
        {
            AllTagsService tagsService = CreateAllTagsService();
            var tags = tagsService.GetAllTags();
            return Ok(tags);
        }
        public IHttpActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAllTagsService();

            if (!service.CreateAllTags())
                return BadRequest("List of tags already exists");

            return Ok();
        }
        public IHttpActionResult Put(AllTagsEdit tags)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateAllTagsService();

            if (!service.UpdateAllTags(tags)) return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(AllTagsEdit tags)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateAllTagsService();

            if (!service.DeleteTags(tags)) return BadRequest("Tag does not exist");

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
