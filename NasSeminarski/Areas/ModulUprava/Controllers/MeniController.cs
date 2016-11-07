using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava.Controllers
{
    public class MeniController : Controller
    {
        // GET: ModulUprava/Meni
        public ActionResult Index()
        {
            return View();
        }
    }
}