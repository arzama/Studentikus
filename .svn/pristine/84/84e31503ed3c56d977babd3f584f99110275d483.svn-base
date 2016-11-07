using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulDomar
{
    public class ModulDomarAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulDomar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulDomar_default",
                "ModulDomar/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}