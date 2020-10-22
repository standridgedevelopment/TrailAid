using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.User;

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
                var testing = ctx.SaveChanges();
                return true;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Users.Where(e => e.ID == _userId).Select
                    (e => new UserListItem
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                    }
                    );
                return query.ToArray();
            }

        }
        public UserDetail GetUserByLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.LastName == lastName);
                return new UserDetail
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    City = entity.City,
                    State = entity.State
                };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.ID == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.LastName == lastName && e.ID == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
