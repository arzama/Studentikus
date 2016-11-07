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
    public class LoginController : Controller
    {
        private MojContext ctx = new MojContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Provjera(string username, string password, string zapamti)
        {
            Korisnik k = ctx.Korisnici
                ////.Include(x => x.Student)
                //.Include(x => x.Zaposlenik)
                
                .SingleOrDefault(x => x.KorisnickoIme == username && x.Lozinka == password);
            if (k == null)
            {
                return Redirect("/Login");
            }
            
            Autentifikacija.PokreniNovuSesiju(k, HttpContext, (zapamti == "on"));
            Korisnik korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            if (korisnik.UlogeId==1)
                return RedirectToAction("Sobarica2", "ModulSobarica2", new { });

            if (korisnik.UlogeId == 2)
                return RedirectToAction("Meni", "ModulRecepcioner", new { });
            if (korisnik.UlogeId == 9)
                return RedirectToAction("Obroci", "ModulStudent", new { });

            if (korisnik.UlogeId == 4)
                return RedirectToAction("Domar", "ModulDomar", new { });

            if (korisnik.UlogeId == 5)
                return RedirectToAction("Gost", "ModulGost", new { });

            if (korisnik.UlogeId == 6)
                return RedirectToAction("Meni", "ModulUprava", new { });
            if (korisnik.UlogeId == 1009)
                return RedirectToAction("Racunovodja", "ModulRacunovodja", new { });
            return Redirect("/Login");
        }

        public ActionResult Logout()
        {
            Autentifikacija.PokreniNovuSesiju(null, HttpContext, true);
            return Redirect("Index");
        }
    }
}