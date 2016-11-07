using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulRacunovodja
{
    public class ModulRacunovodjaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulRacunovodja";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulRacunovodja_default",
                "ModulRacunovodja/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}