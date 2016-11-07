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
    public class RezervacijaController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: ModulGost/Rezervacija
        public List<Int32> ListSobe { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrikaziSlobodneSobe2(int? brojOsoba)
        {
           
            var model = ctx.Sobe.Where(x=>x.BrojOsoba==brojOsoba).ToList();
            return View("PrikaziSlobodneSobe",model);

        }
      

        public ActionResult PrikaziSlobodneSobe(int? brojOsoba)
        {
            List<Soba>nesto = TempData["sobe"] as List<Soba>;
            List<Soba> sveSobe = ctx.Sobe.Where(x=>x.BrojOsoba==brojOsoba).ToList();
            List<Soba> result= new List<Soba>();
           result = sveSobe.Where(p => !nesto.Any(p2 => p2.Id == p.Id)).ToList();
          
            return View(result);

        }
  
        public ActionResult Prikazi(DateTime? datumPrijave, DateTime? datumOdjave,int? brojOsoba)
        {
            var model = new RezervacijePrikaziVM();

            if (datumPrijave > DateTime.Now || datumOdjave > datumPrijave)
            {
                ListSobe = new List<Int32>();
                List<RezervacijaSobe> RS = new List<RezervacijaSobe>();
                var provjera = ctx.RezervacijeSoba.Include(x => x.Soba).Where(x => x.DatumPrijave == datumPrijave || x.DatumOdjave == datumOdjave || (datumPrijave > x.DatumPrijave && datumPrijave < x.DatumOdjave)
                    || (datumOdjave > x.DatumPrijave && datumOdjave < x.DatumOdjave)).ToList();
                var provjera2 = ctx.Sobe.Where(x => x.BrojOsoba == brojOsoba).FirstOrDefault();
                List<Soba> S = ctx.Sobe.ToList();
                List<Soba> broj = new List<Soba>();
                List<Soba> SlobodneSobe = new List<Soba>();
                if (provjera.Count != 0)
                {
                    RS.AddRange(provjera);

                    foreach (var item in RS)
                    {
                        foreach (var i in S)
                        {
                            if (item.SobaId == i.Id)
                            {
                                broj.Add(i);
                             
                            }

                        }
                    }
                    TempData["sobe"] = broj;
                    TempData["datumPocetka"] = datumPrijave;
                    TempData["datumKraja"] = datumOdjave;
                   
                    return RedirectToAction("PrikaziSlobodneSobe", new { brojOsoba });

                }

                if (provjera.Count == 0 && datumPrijave.HasValue && datumOdjave.HasValue)
                {
                   
                    List<Soba> sobe = ctx.Sobe.Where(x => x.BrojOsoba == brojOsoba).ToList();
                    TempData["datumPocetka"] = datumPrijave;
                    TempData["datumKraja"] = datumOdjave;
                    return RedirectToAction("PrikaziSlobodneSobe2", new { brojOsoba });
                }
            }

            else
                if (datumPrijave.HasValue && datumOdjave.HasValue && (datumPrijave < DateTime.Now || datumOdjave < datumPrijave))
            {
                ModelState.AddModelError("hu", "Datum prijave treba biti veći od današnjeg i veći od datuma odjave !");
                return View("Prikazi", model);
            }
           
           return View("Prikazi",model);

        }


        public ActionResult Dodaj()
        {
            RezervacijeUrediVM Model = new RezervacijeUrediVM();
            return View("Uredi", Model);
        }

        public ActionResult Uredi(int? raId)
        {
            RezervacijeUrediVM Model = new RezervacijeUrediVM();
            Soba soba = ctx.Sobe.Where(x => x.Id == raId).Include(x=>x.StatusSobe).FirstOrDefault();
            RezervacijaSobe rezervacija = new RezervacijaSobe();
            rezervacija.Soba=soba;

            Model.Id = rezervacija.Id;
            Model.BrojSobe=rezervacija.Soba.BrojSobe;

            return RedirectToAction("Snimi", Model);
        }
        public ActionResult Ponisti(int Id)
        {

            RezervacijaRestorana rezervacija = ctx.RezervacijaRestorana.Include(x => x.Desavanja).Where(x => x.Id == Id).FirstOrDefault();

            ctx.RezervacijaRestorana.Find(Id).Desavanja.Otkazano = true;
            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }
        public ActionResult Snimi(RezervacijeUrediVM rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", rezervacija);
            }
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            RezervacijaSobe rezervacijaDB;

            if (rezervacija.Id == 0)
            {
                rezervacijaDB = new RezervacijaSobe();
                rezervacijaDB.Soba = ctx.Sobe.Where(x => x.BrojSobe == rezervacija.BrojSobe).Include(o => o.StatusSobe).FirstOrDefault();

                ctx.RezervacijeSoba.Add(rezervacijaDB);
            }
            else
            {
                rezervacijaDB = ctx.RezervacijeSoba.Where(x => x.Id == rezervacija.Id).FirstOrDefault();

            }
            rezervacijaDB.DatumPrijave = TempData["datumPocetka"] as DateTime?;
            rezervacijaDB.DatumOdjave =TempData["datumKraja"] as DateTime?;
            rezervacijaDB.KorisnikId=k.Id;
            rezervacijaDB.Soba.BrojSobe = rezervacija.BrojSobe;
          
                ctx.SaveChanges();

            return RedirectToAction("Dodaj", "Recenzije", new { });

        }
    }
}

