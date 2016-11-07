using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
    public class MeniController : Controller
    {
        // GET: ModulRecepcioner/Meni
        public ActionResult Index()
        {
            return View();
        }
    }
}