using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrailAid.WebAPI.Controllers
{
    [Authorize]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ValuesController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        // GET api/values
        /// <summary>
        /// Get All Values
        /// </summary>
        /// <returns>Returns a List of All Values</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// Get Value By ID
        /// </summary>
        /// <param name="id"> value id</param>
        /// <returns>Returns Value Object by ID</returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Create a New Value
        /// </summary>
        /// <returns>Returns A New Value</returns>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary> Update Value </summary>
        /// <param name="id"> value id </param>
        /// <param name="value"></param>
        /// <returns> Updates Value Object </returns>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Delete Value
        /// </summary>
        /// <param name="id"> value id</param>
        /// <returns>Deletes Value Object</returns>
        public void Delete(int id)
        {
        }
    }
}
