using NasSeminarski.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.Areas.ModulRecepcioner.Models;
using System.Data.Entity;
using MVC.Helper;
namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
      [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class SalaController : Controller
    {
      
        // GET: Recepcioneri/Sala
        public ActionResult Index()
        {
            return View("Index");
        }
        MojContext ctx = new MojContext();

        public ActionResult Prikazi()
        {
            RezervacijaSalePrikaziViewModel Model = new RezervacijaSalePrikaziViewModel();
            Model.rezervacije = ctx.RezervacijeSala.Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Zaposlenik.Korisnik).Include(x => x.Desavanja.Racun)
                .Select(x => new RezervacijaSalePrikaziViewModel.Rezervacije
           {
               rezervacijaId = x.Id,
               Naziv=x.Desavanja.Naziv,
               Datum = x.Desavanja.Datum,
               Opis = x.Desavanja.Opis,
               Ime=x.Desavanja.Ime,
               Prezime=x.Desavanja.Prezime,
               BrojTelefona = x.Desavanja.BrojTelefona,
               Iznos=x.Desavanja.Racun.Iznos
           }).ToList();

            return View("Prikazi", Model);

        }

        public ActionResult Dodaj()
        {
            RezervacijaSaleUrediVM Model = new RezervacijaSaleUrediVM();
            return View("Uredi", Model);
        }
        public ActionResult Obrisi(int Id)
        {
            RezervacijaSale x=ctx.RezervacijeSala.Find(Id);
            ctx.RezervacijeSala.Remove(x);
            ctx.SaveChanges();
            return RedirectToAction("Prikazi");
        }
       
        public ActionResult Uredi(int Id)
        {
            RezervacijaSaleUrediVM Model = new RezervacijaSaleUrediVM();

            RezervacijaSale rezervacija = ctx.RezervacijeSala.Where(x=>x.Id==Id).Include(x => x.Desavanja)
                .Include(x => x.Desavanja.Zaposlenik.Korisnik)
                .Include(x => x.Desavanja.Racun).FirstOrDefault();


            Model.Id = rezervacija.Id;
            Model.Naziv = rezervacija.Desavanja.Naziv;
            Model.Datum = rezervacija.Desavanja.Datum;
            Model.Opis = rezervacija.Desavanja.Opis;
            Model.Ime = rezervacija.Desavanja.Ime;
            Model.Prezime = rezervacija.Desavanja.Prezime;
            Model.BrojTelefona = rezervacija.Desavanja.BrojTelefona;
            Model.Iznos = rezervacija.Desavanja.Racun.Iznos;

            return View("Uredi",Model);
        }


        public ActionResult Snimi(RezervacijaSaleUrediVM rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", rezervacija);
            }

            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            RezervacijaSale rezervacijaDB;

            if(rezervacija.Id==0)
            {
                rezervacijaDB = new RezervacijaSale();
                rezervacijaDB.Desavanja = new Desavanja();
                rezervacijaDB.Desavanja.Racun = new Racun();
                rezervacijaDB.Desavanja.Zaposlenik = ctx.Zaposlenici.Find(k.Id);
                ctx.RezervacijeSala.Add(rezervacijaDB);
            }
            else
            {
                rezervacijaDB = ctx.RezervacijeSala.Where(x => x.Id == rezervacija.Id).Include(x => x.Desavanja).
                    Include(x => x.Desavanja.Racun).Include(x=>x.Desavanja.Zaposlenik).
                    FirstOrDefault();

            }

            rezervacijaDB.Desavanja.Naziv = rezervacija.Naziv;
            rezervacijaDB.Desavanja.Datum = rezervacija.Datum;
            rezervacijaDB.Desavanja.Opis = rezervacija.Opis;
            rezervacijaDB.Desavanja.Racun.Iznos = rezervacija.Iznos;
            rezervacijaDB.Desavanja.ZaposlenikId = k.Id;
            rezervacijaDB.Desavanja.Ime = rezervacija.Ime;
            rezervacijaDB.Desavanja.Prezime = rezervacija.Prezime;
            rezervacijaDB.Desavanja.BrojTelefona = rezervacija.BrojTelefona;

            
            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }
    }
}