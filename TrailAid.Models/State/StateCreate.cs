﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailAid.Models.State
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class StateCreate
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// state name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
