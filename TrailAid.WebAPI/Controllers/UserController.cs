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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Returns a List of All Users</returns>
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var user = userService.GetUsers();
            return Ok(user);
        }
        /// <summary>
        /// Create a New User
        /// </summary>
        /// <returns>Returns A New User</returns>
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userService = CreateUserService();

            if (!userService.CreateUser(user))
                return InternalServerError();

            return Ok();
        }
        /// <summary> Update City </summary>
        /// <param name="user"> user id </param>
        /// <returns> Updates City Object </returns>
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userService = CreateUserService();

            if (!userService.UpdateUser(user)) return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"> user id</param>
        /// <returns>Deletes User Object</returns>
        public IHttpActionResult Delete(string id)
        {
            var userService = CreateUserService();

            if (!userService.DeleteUser(id)) return InternalServerError();

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

