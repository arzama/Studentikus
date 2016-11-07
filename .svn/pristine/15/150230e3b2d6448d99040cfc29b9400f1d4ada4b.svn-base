using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulSobarica2
{
    public class ModulSobarica2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulSobarica2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulSobarica2_default",
                "ModulSobarica2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}