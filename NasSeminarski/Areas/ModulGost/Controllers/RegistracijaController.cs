using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.Areas.ModulGost.Models;
using NasSeminarski.DAL;
using NasSeminarski.Helper;
using MVC.Helper;
namespace NasSeminarski.Areas.ModulGost.Controllers
{
    [Autorizacija(KorisnickeUloge.Gost)]
    public class RegistracijaController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: ModulGost/Registracija
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Snimi(RegistracijaDodajViewModel korisnik)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi");
            }
            Korisnik korisnikDB;
            
            if (korisnik.Id == 0)
            {
                korisnikDB = new Korisnik();
                
                ctx.Korisnici.Add(korisnikDB);
            }

            else
            {
                korisnikDB = ctx.Korisnici.Where(o => o.Id == korisnik.Id).FirstOrDefault();
            }


            korisnikDB.Ime = korisnik.Ime;
            korisnikDB.Prezime = korisnik.Prezime;
            korisnikDB.DatumRodjenja = korisnik.DatumRodjenja;
            korisnikDB.Adresa = korisnik.Adresa;
            korisnikDB.Email = korisnik.Email;
            korisnikDB.Kontakt = korisnik.Kontakt;
            korisnikDB.KorisnickoIme = korisnik.KorisnickoIme;
            korisnikDB.Lozinka = korisnik.Lozinka;
            korisnikDB.UlogeId = 5;

            ctx.SaveChanges();
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        public ActionResult Dodaj(int? korisnikId)
        {
            RegistracijaDodajViewModel Model = new RegistracijaDodajViewModel();
            
            return View("Uredi", Model);
        }
        public ActionResult Uredi(int? koId)
        {
            RegistracijaDodajViewModel Model = new RegistracijaDodajViewModel();
            if(koId==0)
            {
                Korisnik korisnik = ctx.Korisnici.FirstOrDefault();

                Model.Id = korisnik.Id;
                Model.Ime = korisnik.Ime;
                Model.Prezime = korisnik.Prezime;
                Model.DatumRodjenja = korisnik.DatumRodjenja;
                Model.Adresa = korisnik.Adresa;
                Model.Email = korisnik.Email;
                Model.Kontakt = korisnik.Kontakt;
                Model.KorisnickoIme = korisnik.KorisnickoIme;
                Model.Lozinka = korisnik.Lozinka;
                

                
            }
            else
            {
                Korisnik korisnik = ctx.Korisnici.Where(x=>x.Id==koId).FirstOrDefault();
            }
            return View("Uredi", Model);

          
        }
    }
}