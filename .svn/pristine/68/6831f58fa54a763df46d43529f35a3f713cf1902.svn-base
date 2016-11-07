using MVC.Helper;
using NasSeminarski.DAL;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            if (k == null)
                return Redirect("/Login");
            return View(k);
        }

    }
}
