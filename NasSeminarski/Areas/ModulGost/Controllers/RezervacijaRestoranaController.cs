using NasSeminarski.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.Areas.ModulGost.Models;
using System.Data.Entity;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulGost.Controllers
{
       [Autorizacija(KorisnickeUloge.Gost)]
    public class RezervacijaRestoranaController : Controller
    {
     
        MojContext ctx = new MojContext();

        // GET: ModulGost/RezervacijaRestorana
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prikazi()
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            RestoranPrikaziVM Model = new RestoranPrikaziVM();
            Model.rezervacije = ctx.RezervacijaRestorana.Where(x => x.Desavanja.Korisnik.Id == k.Id).Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Racun).OrderBy(x=>x.Desavanja.Datum)
                .Select(x => new RestoranPrikaziVM.Rezervacije
                {
                    RezervacijaId = x.Id,
                    Naziv = x.Desavanja.Naziv,
                    Datum = x.Desavanja.Datum,
                    Opis = x.Desavanja.Opis,
                }).ToList();

            return View("Prikazi", Model);

        }
        public ActionResult Dodaj()
        {
            RestoranUrediVM Model = new RestoranUrediVM();
            return View("Uredi", Model);
        }

        public ActionResult Uredi(int? Id)
        {
            RestoranUrediVM Model = new RestoranUrediVM();

            RezervacijaRestorana rezervacija = ctx.RezervacijaRestorana.Where(x => x.Id == Id).Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Racun).FirstOrDefault();

            
                Model.Id = rezervacija.Id;
                Model.Naziv = rezervacija.Desavanja.Naziv;
                Model.Datum = rezervacija.Desavanja.Datum;
                Model.Opis = rezervacija.Desavanja.Opis;
         
           


            return View("Uredi", Model);
        }
        public ActionResult Ponisti(int Id)
        {

            RezervacijaRestorana rezervacija = ctx.RezervacijaRestorana.Include(x => x.Desavanja).Where(x => x.Id == Id).FirstOrDefault();

            ctx.RezervacijaRestorana.Find(Id).Desavanja.Otkazano = true;
            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }
        public ActionResult Snimi(RestoranUrediVM rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", rezervacija);
            }
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            var provjera = ctx.RezervacijaRestorana.Where(x => rezervacija.Datum < DateTime.Now).FirstOrDefault();
            RezervacijaRestorana rezervacijaDB;

            if (rezervacija.Id == 0)
            {
                rezervacijaDB = new RezervacijaRestorana();
                rezervacijaDB.Desavanja = new Desavanja();
                rezervacijaDB.Desavanja.Racun = new Racun();
                ctx.RezervacijaRestorana.Add(rezervacijaDB);
            }
            else
            {
                rezervacijaDB = ctx.RezervacijaRestorana.Where(x => x.Id == rezervacija.Id).Include(x => x.Desavanja.Korisnik).Include(x => x.Desavanja).
                    Include(x => x.Desavanja.Racun).
                    FirstOrDefault();

            }
            if (rezervacija.Datum > DateTime.Now)
            {
                rezervacijaDB.Desavanja.Naziv = rezervacija.Naziv;
                rezervacijaDB.Desavanja.Datum = rezervacija.Datum;
                rezervacijaDB.Desavanja.Opis = rezervacija.Opis;
                rezervacijaDB.Desavanja.KorisnikId = k.Id;
                rezervacijaDB.Desavanja.Ime = k.Ime;
                rezervacijaDB.Desavanja.Prezime = k.Prezime;
                rezervacijaDB.Desavanja.BrojTelefona = k.Kontakt;
            }
            else
            {
                ModelState.AddModelError("huhu", "Datum rezervacije treba biti veći od današnjeg !");
                return View("Uredi", rezervacija);
            }
            if (provjera == null)
                ctx.SaveChanges();
            else
                return RedirectToAction("Dodaj");
             
            return RedirectToAction("Prikazi");
        }
    }
}