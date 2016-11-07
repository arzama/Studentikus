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
    public class DesavanjaController : Controller
    {
        
        private MojContext db = new MojContext();
        // GET: ModulRecepcioner/Desavanja
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.Desavanja.ToList();
            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
                [Required(ErrorMessage = "Naziv dešavanja je obavezno polje")]
            public string Naziv { get; set; }
                [Required(ErrorMessage = "Datum je obavezno polje")]
            public DateTime Datum { get; set; }
                [Required(ErrorMessage = "Opis je obavezno polje")]
            public string Opis { get; set; }
                [Required(ErrorMessage = "Ime je obavezno polje")]
            public string Ime { get; set; }
                [Required(ErrorMessage = "Prezime je obavezno polje")]
            public string Prezime { get; set; }
                [Required(ErrorMessage = "Broj telefona je obavezno polje")]
            public string BrojTelefona { get; set; }
            public bool Otkazano { get; set; }

        }
        public ActionResult Uredi(int desavanjeId)
        {
            var x = db.Desavanja.Find(desavanjeId);
            var model = new UrediVM
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Datum = Convert.ToDateTime(x.Datum),
                Opis = x.Opis,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojTelefona = x.BrojTelefona,
                Otkazano = Convert.ToBoolean(x.Otkazano)
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                Naziv = "",
                Opis = "",
                Datum = DateTime.Now,
                Ime = "",
                Prezime = "",
                BrojTelefona = "",
                Otkazano = false
            };
            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Desavanja x;
            if(!ModelState.IsValid)
            {
                return View("Uredi", model);
            }
          

            if (model.Id == 0)
            {
                x = new Desavanja();
                db.Desavanja.Add(x);
            }
            else
            {
                x = db.Desavanja.Find(model.Id);
            }

            x.Naziv = model.Naziv;
            x.Opis = model.Opis;
            x.Datum = model.Datum;
            x.Ime = model.Ime;
            x.Prezime = model.Prezime;
            x.BrojTelefona = model.BrojTelefona;
            x.Otkazano = model.Otkazano;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }
    }
}