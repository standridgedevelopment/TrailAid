using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TrailAid.Models.State;
using TrailAid.Services;

namespace TrailAid.WebAPI.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class StateController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Get All States
        /// </summary>
        /// <returns>Returns a List of All States</returns>
        public IHttpActionResult Get()
        {
            StateService stateService = CreateStateService();
            var state = stateService.GetStates();
            return Ok(state);
        }
        /// <summary>
        /// Get State By name
        /// </summary>
        /// <param name="Name"> state id</param>
        /// <returns>Returns State Object by ID</returns>
        public IHttpActionResult Get(string Name)
        {
            StateService StateService = CreateStateService();
            var state = StateService.GetStateByName(Name);
            if (state.Name == null) return BadRequest("State not found");
            return Ok(state);
        }
        private StateService CreateStateService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var stateService = new StateService();
            return stateService;
        }

    }
}
