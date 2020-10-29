using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Models.Visited;

namespace TrailAid.Models.User
{
    public class UserDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<VisitedFavorite> Favorites { get; set; }
    }
}
