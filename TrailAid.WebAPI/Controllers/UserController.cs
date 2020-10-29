using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrailAid.Models.User;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var user = userService.GetUsers();
            return Ok(user);
        }
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user)) return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(string id)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(id)) return InternalServerError();

            return Ok();
        }
        private UserService CreateUserService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userID);
            return userService;
        }
    }
}

