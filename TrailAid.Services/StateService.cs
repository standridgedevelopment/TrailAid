﻿using System;
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
        public State GetStateByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                State state = ctx.States.Single(e => e.Name.Contains(name));
                return state;
            }
        }
    }
}
