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
    public class RezervacijaSaleController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: ModulGost/RezervacijaSale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prikazi()
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            SalaPrikaziVM Model = new SalaPrikaziVM();
            Model.rezervacije = ctx.RezervacijeSala.Where(x => x.Desavanja.Korisnik.Id == k.Id).Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Racun)
                .Select(x => new SalaPrikaziVM.Rezervacije
                {
                    RezervacijaId = x.Id,
                    Naziv = x.Desavanja.Naziv,
                    Datum = x.Desavanja.Datum.Value,
                    Opis = x.Desavanja.Opis,
                }).ToList();

            return View("Prikazi", Model);

        }
        public ActionResult Dodaj()
        {
            SalaUrediVM Model = new SalaUrediVM();
            return View("Uredi", Model);
        }

        public ActionResult Uredi(int? Id)
        {
            SalaUrediVM Model = new SalaUrediVM();

            RezervacijaSale rezervacija = ctx.RezervacijeSala.Where(x => x.Id == Id).Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Racun).FirstOrDefault();


            Model.Id = rezervacija.Id;
            Model.Naziv = rezervacija.Desavanja.Naziv;
            DateTime.Parse(rezervacija.Desavanja.Datum.ToString(), null, System.Globalization.DateTimeStyles.None);
            Model.Datum =rezervacija.Desavanja.Datum;
            Model.Opis = rezervacija.Desavanja.Opis;


            return View("Uredi", Model);
        }
        public ActionResult Ponisti(int Id)
        {

            RezervacijaSale rezervacija = ctx.RezervacijeSala.Include(x => x.Desavanja).Where(x => x.Id == Id).FirstOrDefault();
        
                ctx.RezervacijeSala.Find(Id).Desavanja.Otkazano = true;
                ctx.SaveChanges();
            
            return RedirectToAction("Prikazi");
        }
        public ActionResult Snimi(SalaUrediVM rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", rezervacija);
            }
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            RezervacijaSale rezervacijaDB;
            var provjera = ctx.RezervacijeSala.Where(x => x.Desavanja.Datum == rezervacija.Datum && rezervacija.Id==null || rezervacija.Datum<DateTime.Now).FirstOrDefault();


            if (rezervacija.Id == 0)
            {
                rezervacijaDB = new RezervacijaSale();
                rezervacijaDB.Desavanja = new Desavanja();
                rezervacijaDB.Desavanja.Racun = new Racun();
                rezervacijaDB.Desavanja.Zaposlenik = ctx.Zaposlenici.Find(k.Id);
                ctx.RezervacijeSala.Add(rezervacijaDB);
            }
            else
            {
                rezervacijaDB = ctx.RezervacijeSala.Where(x => x.Id == rezervacija.Id).Include(x => x.Desavanja.Korisnik).Include(x => x.Desavanja).
                    Include(x => x.Desavanja.Racun).
                    FirstOrDefault();

            }
            if (rezervacija.Datum > DateTime.Now)
            {
                rezervacijaDB.Desavanja.Naziv = rezervacija.Naziv;
                rezervacijaDB.Desavanja.Datum = rezervacija.Datum.Value;
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