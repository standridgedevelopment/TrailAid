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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AllTagsController : ApiController
    {
        public string result = "";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        /// <summary>
        /// Get All Tags
        /// </summary>
        /// <returns>Returns a List of All Tags</returns>
        public IHttpActionResult Get()
        {
            AllTagsService allTagsService = CreateAllTagsService();
            var tags = allTagsService.GetAllTags();
            return Ok(tags);
        }
        /// <summary>
        /// Create a New List of Tags
        /// </summary>
        /// <returns>Returns A New List of Tags</returns>
        public IHttpActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allTagsService = CreateAllTagsService();

            if (!allTagsService.CreateAllTags())
                return BadRequest("List of tags already exists");

            return Ok();
        }
        /// <summary> Update Tags </summary>
        /// <param name="tags"></param>
        /// <returns> Returns a List of Updated Tags </returns>
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
