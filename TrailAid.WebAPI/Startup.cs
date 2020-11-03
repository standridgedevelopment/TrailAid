using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TrailAid.WebAPI.Startup))]

namespace TrailAid.WebAPI
{
    public partial class Startup
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void Configuration(IAppBuilder app)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            ConfigureAuth(app);
        }
    }
}
