using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.DAL;
using MVC.Helper;
using System.ComponentModel.DataAnnotations;
namespace NasSeminarski.Areas.ModulRacunovodja.Controllers
{
    [Autorizacija(KorisnickeUloge.Racunovodja)]
    public class RacunovodjaController : Controller
    {
        private MojContext db = new MojContext();
        // GET: ModulRacunovodja/Racunovodja
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Prikazi()
        {
            var model = db.Zaduzenje.ToList();
            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
              [Required(ErrorMessage = "Iznos zaduženja je obavezno polje")]
            public double Iznos { get; set; }
            public bool Placeno { get; set; }
            public List<SelectListItem> KorisnikStavka { get; set; }
            public int KorisnikId { get; set; }
        }

        public ActionResult Uredi(int zaduzenjeId)
        {
            var x = db.Zaduzenje.Find(zaduzenjeId);
            var model = new UrediVM
            {
                Id = x.Id,
                Iznos = x.IznosZaduzenja,
                Placeno = x.Placeno,
                KorisnikId = x.KorisnikId,
                KorisnikStavka = KorisnikStavka()
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                Iznos = 0,
                Placeno = false,
                KorisnikStavka = KorisnikStavka()
            };
            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Zaduzenja x;
            if(!ModelState.IsValid)
            {
                model.KorisnikStavka = KorisnikStavka();
                return View("Uredi", model);
            }
            if(model.Id==0)
            {
                x = new Zaduzenja();
                db.Zaduzenje.Add(x);
            }else
            {
                x = db.Zaduzenje.Find(model.Id);
            }

            x.IznosZaduzenja = model.Iznos;
            x.Placeno = model.Placeno;
            x.KorisnikId = model.KorisnikId;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }

        private List<SelectListItem> KorisnikStavka()
        {
            var korisnici = new List<SelectListItem>();
            korisnici.Add(new SelectListItem { Value = null, Text = "(ODABERITE KORISNIKA)" });


            var allKorisnici = db.Korisnici.ToList();
            foreach (var item in allKorisnici)
            {
                korisnici.Add(new SelectListItem { Value = item.Id.ToString(), Text = " KORISNIK: " + item.Ime + item.Prezime });
            }
            return korisnici;
        }
    }
}
