using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Areas.ModulGost.Models;
using NasSeminarski.DAL;
using System.Data.Entity;
using NasSeminarski;
using NasSeminarski.Areas;
using NasSeminarski.Controllers;
using NasSeminarski.Models;

using NasSeminarski.Helper;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulGost.Controllers
{
    [Autorizacija(KorisnickeUloge.Gost)]
    public class GostController : Controller
    {
        // GET: ModulGost/Gost
        public ActionResult Index()
        {
            return View();
        }
        MojContext ctx = new MojContext();




        public ActionResult Prikazi()
        {

            SobaPrikaziViewModel Model = new SobaPrikaziViewModel();
            Model.sobe = ctx.Sobe.Include(x => x.StatusSobe).ToList();

            return View("Prikazi", Model);
        }


        public ActionResult PrikaziRezervaciju()
        {

            RezervacijaPrikaziViewModel Model = new RezervacijaPrikaziViewModel();
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
      
            Model.rezervacije = ctx.RezervacijeSoba.OrderByDescending(x => x.DatumPrijave).Include(x => x.Soba).Include(x => x.Korisnik)
           .Where(x => x.KorisnikId == k.Id).Select(x => new RezervacijaPrikaziViewModel.Rezervacije
           {
               rezervacijaId = x.Id,

               DatumPrijave = x.DatumPrijave,
               DatumOdjave = x.DatumOdjave,
               BrojSobe = x.Soba.BrojSobe,
               Iznos=DbFunctions.DiffDays(x.DatumPrijave,x.DatumOdjave)*x.Soba.Cijena

           }).ToList();
            

          return View("PrikaziRezervaciju", Model);
      
           
        }
        public ActionResult Dodaj(int? sobaId)
        {
            RezervacijaUrediViewModel Model = new RezervacijaUrediViewModel();
            Model.BrojSobe = ctx.Sobe.Find(sobaId).BrojSobe;
            return View("Uredi", Model);
        }



        public ActionResult Snimi(RezervacijaUrediViewModel rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", rezervacija);
            }

            RezervacijaSobe rezervacijaDB;
            Korisnik korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            var provjera = ctx.RezervacijeSoba.Where(x => x.Soba.BrojSobe == rezervacija.BrojSobe).Where(x => x.DatumPrijave == rezervacija.DatumPrijave)
              .Where(x => x.DatumOdjave == rezervacija.DatumOdjave).
              FirstOrDefault();

           
                if (rezervacija.Id == 0)
                {
                    rezervacijaDB = new RezervacijaSobe();
                    rezervacijaDB.Korisnik = ctx.Korisnici.Find(korisnik.Id);
                    rezervacijaDB.Soba = ctx.Sobe.Where(x => x.BrojSobe == rezervacija.BrojSobe).Include(o => o.StatusSobe).FirstOrDefault();

                    ctx.RezervacijeSoba.Add(rezervacijaDB);
                }

                else
                {
                    rezervacijaDB = ctx.RezervacijeSoba.Where(o => o.Id == rezervacija.Id).Include(o => o.Soba).Include(o => o.Korisnik).FirstOrDefault();
                }

               
                    rezervacijaDB.DatumPrijave =Convert.ToDateTime( rezervacija.DatumPrijave);
                    rezervacijaDB.DatumOdjave = Convert.ToDateTime(rezervacija.DatumOdjave);
                    rezervacijaDB.Soba.BrojSobe = rezervacija.BrojSobe;
                    rezervacijaDB.KorisnikId = korisnik.Id;
                    rezervacijaDB.Soba.StatusSobeId = 1;
            
           
            DateTime d = DateTime.Now;
            if (provjera == null && rezervacija.DatumPrijave>=d)
            {
                ctx.SaveChanges();
            }
            else if (provjera != null)
            {
            
                RedirectToAction("Prikazi");
                
            }
            
            return RedirectToAction("PrikaziRezervaciju");

        }



        public ActionResult Uredi(int? raId)
        {

            RezervacijaUrediViewModel Model = new RezervacijaUrediViewModel();
            Soba soba = ctx.Sobe.Where(x => x.Id == raId).Include(x=>x.StatusSobe).FirstOrDefault();
            RezervacijaSobe rezervacija = new RezervacijaSobe();
            rezervacija.Soba = soba;
            Korisnik korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);


                Model.Id = rezervacija.Id;
                Model.DatumPrijave =Convert.ToDateTime( rezervacija.DatumPrijave);
                Model.DatumOdjave = rezervacija.DatumOdjave;
                Model.BrojSobe = rezervacija.Soba.BrojSobe;
                Model.Status = rezervacija.Soba.StatusSobeId=1;
            
            return View("Uredi", Model);
        }



        public ActionResult Ponisti(int raId)
        {
          
            RezervacijaSobe x = ctx.RezervacijeSoba.Find(raId);
            DateTime m = DateTime.Now;
            
            if (m.AddDays(5) < x.DatumPrijave)
            {
                ctx.RezervacijeSoba.Find(raId).Otkazana = true;
                ctx.SaveChanges();
            }
          
            return RedirectToAction("PrikaziRezervaciju");
        }
    }
}