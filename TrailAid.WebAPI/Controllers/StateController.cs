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
        /// Get State By ID
        /// </summary>
        /// <param name="id"> state id</param>
        /// <returns>Returns State Object by ID</returns>
        public IHttpActionResult Get(int id)
        {
            StateService StateService = CreateStateService();
            var state = StateService.GetStateByID(id);
            if (state.Name == null) return BadRequest("State ID not found");
            return Ok(state);
        }
        /// <summary>
        /// Create a New State
        /// </summary>
        /// <returns>Returns A New State</returns>
        public IHttpActionResult Post(StateCreate state)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stateService = CreateStateService();

            if (!stateService.CreateStates(state)) return InternalServerError();

            return Ok();
        }
        /// <summary> Update State </summary>
        /// <param name="id"> state id </param>
        /// <param name="state"></param>
        /// <returns> Updates State Object </returns>
        public IHttpActionResult Put(StateEdit state, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateStateService();

            if (!service.UpdateState(state, id)) return BadRequest("State ID not found.");
            return Ok();
        }
        /// <summary>
        /// Delete State
        /// </summary>
        /// <param name="id"> state id</param>
        /// <returns>Deletes State Object</returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateStateService();

            if (!service.DeleteState(id)) return BadRequest("State ID not found.");

            return Ok();
        }
        private StateService CreateStateService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var stateService = new StateService();
            return stateService;
        }

    }
}
