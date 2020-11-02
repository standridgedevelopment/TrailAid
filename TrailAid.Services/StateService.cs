using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.State;
using static TrailAid.Data.ApplicationUser;

namespace TrailAid.Services
{
    public class StateService
    {
        public bool CreateStates(StateCreate model)
        {
            var entity = new State()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.States.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StateListItem> GetStates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.States.Select
                    (e => new StateListItem
                    {
                        Name = e.Name,
                        ID = e.ID
                    }
                    );
                return query.ToArray();
            }

        }
        public StateDetail GetStateByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.States.Single(e => e.ID == id);
                    return new StateDetail
                    {
                        Name = entity.Name
                    };
                }
                catch { }
                return new StateDetail();
            }
        }
        public bool UpdateState(StateEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.States.Single(e => e.ID == id);

                    entity.Name = model.Name;
                }
                catch { return false; }
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteState(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.States.Single(e => e.ID == id);

                    ctx.States.Remove(entity);
                }
                catch { return false; }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
