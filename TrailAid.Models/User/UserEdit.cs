using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.User
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserEdit
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        ///  user first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///  user last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        ///  user city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        ///  user state
        /// </summary>
        public string State { get; set; }
    }
}
