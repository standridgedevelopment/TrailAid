﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Models.Visited;

namespace TrailAid.Models.User
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<VisitedFavorite> Favorites { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
