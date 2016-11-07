using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava
{
    public class ModulUpravaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulUprava";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulUprava_default",
                "ModulUprava/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}