using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.Park;
using TrailAid.Models.User;
using static TrailAid.Data.ApplicationUser;

namespace TrailAid.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                ID = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                State = model.State
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    
        public UserDetail GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Users.Single(e => e.ID == _userId);
                    return new UserDetail
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        City = entity.City,
                        State = entity.State,
                        Favorites = entity.Favorites
                    };
                }
                catch { }
                return new UserDetail();
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.ID == _userId);

                if (model.FirstName != null) entity.FirstName = model.FirstName;
                if (model.LastName != null) entity.LastName = model.LastName;
                if (model.City != null) entity.City = model.City;
                if (model.State != null) entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.ID == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
