using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulRecepcioner
{
    public class ModulRecepcionerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulRecepcioner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulRecepcioner_default",
                "ModulRecepcioner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}