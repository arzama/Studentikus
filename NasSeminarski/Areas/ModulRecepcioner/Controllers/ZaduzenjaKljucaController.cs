using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using System.ComponentModel.DataAnnotations;

using NasSeminarski.DAL;
using MVC.Helper;
namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
       [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class ZaduzenjaKljucaController : Controller
    {
     
        private MojContext db = new MojContext();
        // GET: ModulRecepcioner/ZaduzenjaKljuca
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.ZaduzenjaKljuceva.ToList();
            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
             [Required(ErrorMessage = "Datum preuzimanja je obavezno polje")]
            public DateTime DatumPreuzimanja { get; set; }
             [Required(ErrorMessage = "Datum vracanja je obavezno polje")]
            public DateTime DatumVracanja { get; set; }
            public bool Aktivan { get; set; }
            public List<SelectListItem> KorisnikStavka { get; set; }
            public int KorisnikId { get; set; }
            public List<SelectListItem> KljucStavka { get; set; }
            public int KljucId { get; set; }
        }

        public ActionResult Uredi(int zaduzenjeId)
        {
            var x = db.ZaduzenjaKljuceva.Find(zaduzenjeId);
            var model = new UrediVM
            {
                Id = x.Id,
                DatumPreuzimanja = Convert.ToDateTime(x.DatumPreuzimanja),
                DatumVracanja = Convert.ToDateTime(x.DatumVracanja),
                Aktivan = x.Aktivan,
                KorisnikId = x.KorisnikId,
                KljucId = Convert.ToInt32(x.KljucId),
                KorisnikStavka = KorisnikStavka(),
                KljucStavka = KljucStavka()
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                DatumPreuzimanja = DateTime.Now,
                DatumVracanja = DateTime.Now,
                Aktivan = false,
                KorisnikStavka = KorisnikStavka(),
                KljucStavka = KljucStavka()
            };
            return View("Uredi", model);
        }
        public ActionResult Snimi(UrediVM model)
        {
            ZaduzenjeKljuca x;
            if (!ModelState.IsValid)
            {
                model.KljucStavka = KljucStavka();
                model.KorisnikStavka = KorisnikStavka();

                return View("Uredi", model);

            }

            if (model.Id == 0)
            {
                x = new ZaduzenjeKljuca();
                db.ZaduzenjaKljuceva.Add(x);
            }
            else
            {
                x = db.ZaduzenjaKljuceva.Find(model.Id);
            }
            x.DatumPreuzimanja = model.DatumPreuzimanja;
            x.DatumVracanja = model.DatumVracanja;
            x.Aktivan = model.Aktivan;
            x.KorisnikId = model.KorisnikId;
            x.KljucId = model.KljucId;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }

        private List<SelectListItem> KljucStavka()
        {
            var kljucevi = new List<SelectListItem>();
            kljucevi.Add(new SelectListItem { Value = null, Text = "(ODABERITE KLJUC)" });


            var allKljucevi = db.Kljucevi.ToList();
            foreach (var item in allKljucevi)
            {
                kljucevi.Add(new SelectListItem { Value = item.Id.ToString(), Text = " KlJUC BROJ: " + item.BrojKljuca.ToString() });
            }
            return kljucevi;
        }

        private List<SelectListItem> KorisnikStavka()
        {
            var korisnici = new List<SelectListItem>();
            korisnici.Add(new SelectListItem { Value = null, Text = "(ODABERITE KORISNIKA)" });


            var allKorisnici = db.Korisnici.ToList();
            foreach (var item in allKorisnici)
            {
                korisnici.Add(new SelectListItem { Value = item.Id.ToString(), Text = " KORISNIK: " + item.Ime+item.Prezime });
            }
            return korisnici;
        }



    }
}