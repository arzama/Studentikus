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
    public class RecenzijeController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: ModulGost/Recenzije
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prikazi()
        {

            RecenzijePrikaziVM Model = new RecenzijePrikaziVM();
            Model.recenzije = ctx.Recenzije
                .Select(x => new RecenzijePrikaziVM.Recenzije
                {
                    RecenzijaId = x.Id,
                     Ime=x.Korisnik.Ime,
                     Prezime=x.Korisnik.Prezime,
                    Datum=x.Datum,
                    Komentar = x.Komentar
                }).ToList();

            return View("Prikazi", Model);

        }
        public ActionResult Dodaj()
        {
            RecenzijeUrediVM Model = new RecenzijeUrediVM();
            return View("Uredi", Model);
        }

        public ActionResult Uredi(int? Id)
        {
            RecenzijeUrediVM Model = new RecenzijeUrediVM();
         
                Recenzije recenzija = ctx.Recenzije.Where(x => x.Id == Id).FirstOrDefault();
                Model.Id = recenzija.Id;
                Model.Komentar = recenzija.Komentar;
       
            
     
            return View("Uredi", Model);
        }
    
        public ActionResult Snimi(RecenzijeUrediVM recenzija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", recenzija);
            }
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            Recenzije recenzijaDB;

            if (recenzija.Id == 0)
            {
                recenzijaDB = new Recenzije();
               
                ctx.Recenzije.Add(recenzijaDB);
            }
            else
            {
                recenzijaDB = ctx.Recenzije.Where(x => x.Id == recenzija.Id).
                    FirstOrDefault();

            }

            recenzijaDB.Komentar = recenzija.Komentar;
            recenzijaDB.Datum = DateTime.Now;
            recenzijaDB.KorisnikId = k.Id;

            ctx.SaveChanges();
            return RedirectToAction("Prikazi");

        }
    }
}