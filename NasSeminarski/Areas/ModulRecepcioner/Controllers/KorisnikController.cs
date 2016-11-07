using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.DAL;

using System.ComponentModel.DataAnnotations;
using MVC.Helper;


namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
      [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class KorisnikController : Controller
    {
         
        private MojContext db = new MojContext();
        // GET: ModulRecepcioner/Korisnik
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.Korisnici.ToList();
            return View(model);
        }
        public class UrediVM
        {
            public int Id { get; set; }
             [Required(ErrorMessage = "Ime je obavezno polje")]
            public string Ime { get; set; }
             [Required(ErrorMessage = "Prezime je obavezno polje")]
            public string Prezime { get; set; }
             [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
            public DateTime DatumRodjenja { get; set; }
             [Required(ErrorMessage = "Adresa je obavezno polje")]
            public string Adresa { get; set; }
             [Required(ErrorMessage = "Email je obavezno polje")]
            public string Email { get; set; }
             [Required(ErrorMessage = "Kontakt je obavezno polje")]
            public string Kontakt { get; set; }
             [Required(ErrorMessage = "Korisnicko ime je obavezno polje")]
            public string KorisnickoIme { get; set; }
             [Required(ErrorMessage = "Lozinka je obavezno polje")]
               [StringLength(30, MinimumLength = 5, ErrorMessage = "Lozinka mora imati najmanje 5 a najviše 30 karaktera")]
            public string Lozinka { get; set; }
            public List<SelectListItem> UlogaStavka { get; set; }
            public int UlogaId { get; set; }
        }

        public ActionResult Uredi(int korisnikId)
        {
            var x = db.Korisnici.Find(korisnikId);
            var model = new UrediVM
            {
                Id = x.Id,
                Ime = x.Ime,
                Prezime = x.Prezime,
                DatumRodjenja = Convert.ToDateTime(x.DatumRodjenja),
                Adresa = x.Adresa,
                Email = x.Email,
                Kontakt = x.Kontakt,
                KorisnickoIme = x.KorisnickoIme,
                Lozinka = x.Lozinka,
                UlogaId = Convert.ToInt32(x.UlogeId),
                UlogaStavka = UlogaStavka()
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                Ime = "",
                Prezime = "",
                DatumRodjenja = DateTime.Now,
                Adresa = "",
                Email = "",
                Kontakt = "",
                KorisnickoIme = "",
                Lozinka = "",
                UlogaStavka = UlogaStavka()
            };
            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Korisnik x;
            if (!ModelState.IsValid)
            {
                model.UlogaStavka = UlogaStavka();

                return View("Uredi", model);

            }

            if(model.Id==0)
            {
                x = new Korisnik();
                db.Korisnici.Add(x);
            }
            else
            {
                x = db.Korisnici.Find(model.Id);
            }

            x.Ime = model.Ime;
            x.Prezime = model.Prezime;
            x.DatumRodjenja = model.DatumRodjenja;
            x.Adresa = model.Adresa;
            x.Email = model.Email;
            x.Kontakt = model.Kontakt;
            x.KorisnickoIme = model.KorisnickoIme;
            x.Lozinka = model.Lozinka;
            x.UlogeId = model.UlogaId;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }

        private List<SelectListItem> UlogaStavka()
        {
            var uloge = new List<SelectListItem>();
            uloge.Add(new SelectListItem { Value = null, Text = "(ODABERITE ULOGU)" });


            var allUloge = db.Uloge.ToList();
            foreach (var item in allUloge)
            {
                uloge.Add(new SelectListItem { Value = item.Id.ToString(), Text = " Uloga: " + item.Naziv });
            }
            return uloge;
        }
    }
}