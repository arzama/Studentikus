using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.Helper;
using MVC.Helper;

namespace NasSeminarski.Controllers
{
    public class MeniController : Controller
    {
        // GET: Meni
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Prikazi()
        {
            Korisnik korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            if (korisnik.Uloge.Naziv == "Domar")
                return RedirectToAction("Index", "ModulDomar", new { });
            if (korisnik.Uloge.Naziv == "Sobarica")
                return RedirectToAction("/ModulSobarica2");
            if (korisnik.Uloge.Naziv == "Recepcioner")
                return RedirectToAction("/ModulRecepcioner");
            if (korisnik.Uloge.Naziv == "Upravnik")
                return RedirectToAction("/ModulUprava");
            if (korisnik.Uloge.Naziv == "Gost")
                return RedirectToAction("/ModulGost");
            else
                return RedirectToAction("Login");
        }

    }
}