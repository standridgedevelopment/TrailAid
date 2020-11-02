using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.User
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserCreate
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// user first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// user last name
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// user city
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// user state
        /// </summary>
        [Required]
        public string State { get; set; }
    }
}
