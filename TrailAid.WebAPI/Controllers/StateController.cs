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
    public class StateController : ApiController
    {
        /// <summary>  
        /// Get all States  
        /// </summary>  
        /// <returns>List of States</returns>
        public IHttpActionResult Get()
        {
            StateService stateService = CreateStateService();
            var state = stateService.GetStates();
            return Ok(state);
        }
        /// <summary>  
        /// Get State By ID  
        /// </summary>  
        /// <param name="id"> State ID</param>  
        /// <returns>State Object by ID </returns>
        public IHttpActionResult Get(int id)
        {
            StateService StateService = CreateStateService();
            var state = StateService.GetStateByID(id);
            if (state.Name == null) return BadRequest("State ID not found");
            return Ok(state);
        }
        public IHttpActionResult Post(StateCreate state)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stateService = CreateStateService();

            if (!stateService.CreateStates(state)) return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(StateEdit state, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateStateService();

            if (!service.UpdateState(state, id)) return BadRequest("State ID not found.");
            return Ok();
        }
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