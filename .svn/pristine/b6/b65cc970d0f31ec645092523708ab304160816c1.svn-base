using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.DAL;
using NasSeminarski.Areas.ModulRecepcioner.Models;

namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
    public class RezervacijeController : Controller
    {
        private MojContext db = new MojContext();
        public ActionResult Index()
        {
            return View("Index");

        }
        public ActionResult Prikazi2(DateTime? datum)
        {
            var model = db.Sobe.ToList();
            ViewData["datum"] = datum ?? DateTime.Now;
            return View("View",model);
        }

        public class IndexVM
        {
            public List<rezervacijeInfo> rezervacije { get; set; }
            public List<SelectListItem> Sobestavke { get; set; }
            public List<SelectListItem> KorisnikStavka { get; set; }
            public int sobaId { get; set; }
            public int KorisnikId { get; set; }
            public class rezervacijeInfo
            {
                public int Id { get; set; }
                public DateTime? DatumPrijave { get; set; }
                public DateTime? DatumOdjave { get; set; }
                public bool? Realizovana { get; set; }
                public bool? Otkazana { get; set; }
                public float Iznos { get; set; }
                public string Soba { get; set; }
                public string Korisnik { get; set; }
                public int? RacunId { get; set; }
            }
        }
        public ActionResult Prikazi(int? sobaId, int? KorisnikId)
        {

            var model = new IndexVM();

            model.rezervacije = db.RezervacijeSoba
                 .Where(x => (!sobaId.HasValue || x.Soba.Id == sobaId) &&
                     (!KorisnikId.HasValue || x.KorisnikId == KorisnikId))
                 .Select(x => new IndexVM.rezervacijeInfo()
                 {
                     Id = x.Id,
                     DatumPrijave = x.DatumPrijave,
                     DatumOdjave = x.DatumOdjave,
                     Realizovana = x.Realizovana,
                     Otkazana = x.Otkazana,
                     //Iznos = x.Racun.Iznos
                     Korisnik = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                     Soba = x.Soba.BrojSobe.ToString(),
                     RacunId = x.RacunId

                 }).ToList();

            model.KorisnikStavka = KorisnikStavke();
            model.Sobestavke = SobaStavke();

            return View("Prikazi", model);
        }


        public class UrediVM
        {
            public int Id { get; set; }
            public DateTime DatumPrijave { get; set; }
            public DateTime DatumOdjave { get; set; }
            public bool Realizovana { get; set; }
            public bool Otkazana { get; set; }
            public int sobaId { get; set; }
            public virtual Soba sobe { get; set; }
            public List<SelectListItem> SobaStavke { get; set; }
            public int korisnikId { get; set; }
            public float Iznos { get; set; }
            public List<SelectListItem> KorisnikStavka { get; set; }
        }

        public ActionResult Uredi(int rezervacijaId)
        {
            var x = db.RezervacijeSoba.Find(rezervacijaId);
            var model = new UrediVM
            {
                Id = x.Id,
                DatumPrijave = Convert.ToDateTime(x.DatumPrijave),
                DatumOdjave = Convert.ToDateTime(x.DatumOdjave),
                Realizovana = Convert.ToBoolean(x.Realizovana),
                Otkazana = Convert.ToBoolean(x.Otkazana),
                sobaId = Convert.ToInt32(x.SobaId),
                SobaStavke = SobaStavke(),
                korisnikId = Convert.ToInt32(x.KorisnikId),
                KorisnikStavka = KorisnikStavke()

            };
            return View(model);
          
        }

        public ActionResult Dodaj()
        {
          
            var model = new UrediVM
            {
                DatumPrijave = DateTime.Now,
                DatumOdjave = DateTime.Now,
                Realizovana = false,
                Otkazana = false,
                SobaStavke = SobaStavke(),
                KorisnikStavka = KorisnikStavke()
            };
            return View("Uredi", model);
        }

        private List<SelectListItem> SobaStavke()
        {
            var sobe = new List<SelectListItem>();
            sobe.Add(new SelectListItem { Value = null, Text = "(ODABERITE SOBU)" });


            var allsobe = db.Sobe.ToList();
            foreach (var item in allsobe)
            {
                sobe.Add(new SelectListItem { Value = item.Id.ToString(), Text = " SOBA BROJ: " + item.BrojSobe.ToString() });
            }
            return sobe;
        }

        private List<SelectListItem> KorisnikStavke()
        {
            var korisnik = new List<SelectListItem>();
            korisnik.Add(new SelectListItem { Value = null, Text = "(ODABERITE KORISNIKA)" });


            var allKorisnici = db.Korisnici.ToList();
            foreach (var item in allKorisnici)
            {
                korisnik.Add(new SelectListItem { Value = item.Id.ToString(), Text = " KORISNIK: " + item.Ime + item.Prezime });
            }
            return korisnik;
        }

        public ActionResult Snimi(UrediVM model)
        {
            RezervacijaSobe x;
            if (model.Id == 0)
            {
                x = new RezervacijaSobe();
                db.RezervacijeSoba.Add(x);
            }
            else
            {
                x = db.RezervacijeSoba.Find(model.Id);
            }
            x.DatumPrijave = model.DatumPrijave;
            x.DatumOdjave = model.DatumOdjave;
            x.Otkazana = false;
            x.Realizovana = false;
            x.SobaId = model.sobaId;
            x.KorisnikId = model.korisnikId;
            if (model.DatumPrijave < model.DatumOdjave && model.DatumPrijave >= DateTime.Now)
            {
                return RedirectToAction("Prikazi2");
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("re", "Datum odjave mora biti veći od datuma prijave!/ Datum prijave mora biti danasnji ili datum veci od danasnjeg");
                model.SobaStavke = SobaStavke();
                model.KorisnikStavka = KorisnikStavke();
                return View("Uredi", model);
            }

            db.SaveChanges();
            return RedirectToAction("Prikazi2");

        }
       
        public ActionResult Ponisti(int raId)
        {

            RezervacijaSobe x = db.RezervacijeSoba.Find(raId);

                db.RezervacijeSoba.Remove(x);
                db.RezervacijeSoba.Find(raId).Otkazana = true;
                db.SaveChanges();
           
            return RedirectToAction("Prikazi2");
        }
    }
}