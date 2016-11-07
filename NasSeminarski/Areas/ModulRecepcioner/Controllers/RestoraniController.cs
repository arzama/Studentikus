using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.DAL;
using System.Data.Entity;
using NasSeminarski;
using NasSeminarski.Areas;
using NasSeminarski.Controllers;
using NasSeminarski.Models;
using NasSeminarski.Areas.ModulRecepcioner.Models;
using NasSeminarski.Helper;
using MVC.Helper;
namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
     [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class RestoraniController : Controller
    {
       
        // GET: Recepcioneri/RezervacijaRestorana
        public ActionResult Index()
        {
            return View("Index");
        }
        MojContext ctx = new MojContext();
        public ActionResult Prikazi()
        {
            RezervacijaRestoranaPrikaziViewModel Model = new RezervacijaRestoranaPrikaziViewModel();
            Model.restorani = ctx.RezervacijaRestorana.Include(x => x.Desavanja).
                Include(x => x.Desavanja.Zaposlenik.Korisnik).Include(x => x.Desavanja.Racun)
            .ToList();

            return View("Prikazi", Model);

        }
        public ActionResult Obrisi(int Id)
        {
            RezervacijaRestorana x = ctx.RezervacijaRestorana.Find(Id);


            ctx.RezervacijaRestorana.Remove(x);
            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }
        public ActionResult Dodaj()
        {
            RezervacijaRestoranaUrediViewModel Model = new RezervacijaRestoranaUrediViewModel();


            return View("Uredi", Model);
        }
        public ActionResult Uredi(int Id)
        {
            RezervacijaRestoranaUrediViewModel Model = new RezervacijaRestoranaUrediViewModel();

            RezervacijaRestorana rezervacija = ctx.RezervacijaRestorana.Where(x => x.Id == Id).Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Zaposlenik.Korisnik)
                .Include(x => x.Desavanja.Racun).FirstOrDefault();


            Model.Id = rezervacija.Id;
            Model.Naziv = rezervacija.Desavanja.Naziv;
            Model.Datum = rezervacija.Desavanja.Datum;
            Model.Opis = rezervacija.Desavanja.Opis;
            Model.Ime = rezervacija.Desavanja.Ime;
            Model.Prezime = rezervacija.Desavanja.Prezime;
            Model.BrojTelefona = rezervacija.Desavanja.BrojTelefona;
            //Model.Iznos = rezervacija.Desavanja.Racun.Iznos;

            return View("Uredi", Model);
        }

        public ActionResult Snimi(RezervacijaRestoranaUrediViewModel rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi");
            }
            RezervacijaRestorana rezervacijaDB;
            Korisnik korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            if(rezervacija.Id==0)
            {
                rezervacijaDB = new RezervacijaRestorana();
                rezervacijaDB.Desavanja = new Desavanja();
                rezervacijaDB.Desavanja.Racun = null;
                rezervacijaDB.Desavanja.Zaposlenik = ctx.Zaposlenici.Find(korisnik.Id);

                ctx.RezervacijaRestorana.Add(rezervacijaDB);
            }
            else
            {
                rezervacijaDB = ctx.RezervacijaRestorana.Where(x => x.Id == rezervacija.Id).Include(x => x.Desavanja).Include(x => x.Desavanja.Racun).FirstOrDefault();
            }

            rezervacijaDB.Desavanja.Naziv = rezervacija.Naziv;
            rezervacijaDB.Desavanja.Datum = rezervacija.Datum;
            rezervacijaDB.Desavanja.Opis = rezervacija.Opis;
            //rezervacijaDB.Desavanja.Racun.Iznos = (float)rezervacija.Iznos;
            rezervacijaDB.Desavanja.ZaposlenikId = korisnik.Id;
            rezervacijaDB.Desavanja.Ime = rezervacija.Ime;
            rezervacijaDB.Desavanja.Prezime = rezervacija.Prezime;
            rezervacijaDB.Desavanja.BrojTelefona = rezervacija.BrojTelefona;


            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }

    }
}