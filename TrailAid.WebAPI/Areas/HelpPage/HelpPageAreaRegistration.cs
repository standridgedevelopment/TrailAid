using System.Web.Http;
using System.Web.Mvc;

namespace TrailAid.WebAPI.Areas.HelpPage
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
