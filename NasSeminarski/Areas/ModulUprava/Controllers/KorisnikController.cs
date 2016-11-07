using Foolproof;
using MVC.Helper;
using NasSeminarski.DAL;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava.Controllers
{
      [Autorizacija(KorisnickeUloge.Upravnik)]
    public class KorisnikController : Controller
    {
        MojContext ctx = new MojContext();

        public class IndexVM
        {
            public int UlogaId { get; set; }
            public List<Korisnik> Korisnik { get; set; }
        
        }
        public ActionResult Index(int ulogaId)
        {
            var model = new IndexVM
            {
                 UlogaId = ulogaId,
                Korisnik = ctx.Korisnici.Where(x => x.UlogeId == ulogaId && x.IsDeleted==false).ToList()

            };
            return View(model);
        }

        public class UrediVM
        {
            public int UlogaId { get; set; }
            public int Id { get; set; }
             [Required(ErrorMessage = "Ime je obavezno polje")]
            public string Ime { get; set; }
            [Required(ErrorMessage = "Prezime je obavezno polje")]
            public string Prezime { get; set; }
            [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
            [DataType(DataType.Date)]
             public DateTime DatumRodjenja { get; set; }
            public string Adresa { get; set; }
             [EmailAddress]
            public string Email { get; set; }
             [Required(ErrorMessage = "Kontakt je obavezno polje")]
            public string Kontakt { get; set; }
             [Required(ErrorMessage = "Korisnicko ime je obavezno polje")]
            public string KorisnickoIme { get; set; }
             [Required(ErrorMessage = "Lozinka je obavezno polje")]
             [StringLength(30, MinimumLength = 5, ErrorMessage = "Lozinka mora imati najmanje 5 a najviše 30 karaktera")]
            public string Lozinka { get; set; }

        }
        public ActionResult Uredi(int korisnikId)
        {
            var x = ctx.Korisnici.Find(korisnikId);
            var model = new UrediVM
            {
               UlogaId=x.UlogeId.Value,
                Id = x.Id,
                Ime = x.Ime,
               Prezime=x.Prezime,
                DatumRodjenja=x.DatumRodjenja.Value,
                 Adresa=x.Adresa,
                  Email=x.Email,
                   Kontakt=x.Kontakt,
                    KorisnickoIme=x.KorisnickoIme,
                     Lozinka=x.Lozinka

            };
            return View("Uredi", model);

        }
        public ActionResult Dodaj(int ulogaId)
        {

            var model = new UrediVM
            {
               DatumRodjenja=DateTime.MinValue,
               UlogaId=ulogaId



            };

            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Korisnik x;
            if (!ModelState.IsValid)
            {
                return View("Uredi", model);

            }

            if (model.Id == 0)
            {
                x = new Korisnik ();
                ctx.Korisnici.Add(x);
            }
            else
            {
                x = ctx.Korisnici.Find(model.Id);

            }

            x.UlogeId = model.UlogaId;
            x.Id = model.Id;
            x.Ime=model.Ime;
            x.Prezime = model.Prezime;
            x.DatumRodjenja = model.DatumRodjenja;
            x.Adresa = model.Adresa;
            x.Email = model.Email;
            x.Kontakt = model.Kontakt;
            x.KorisnickoIme = model.KorisnickoIme;
            x.Lozinka = model.Lozinka;
            ctx.SaveChanges();

            return RedirectToAction("Index", new { ulogaId = model.UlogaId });
        }

      
    }
}