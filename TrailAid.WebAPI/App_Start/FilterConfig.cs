using System.Web;
using System.Web.Mvc;

namespace TrailAid.WebAPI
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
