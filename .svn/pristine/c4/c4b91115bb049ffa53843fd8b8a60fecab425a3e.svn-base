 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Areas.ModulDomar.Models;
using NasSeminarski.DAL;
using System.Data.Entity;
using NasSeminarski;
using NasSeminarski.Areas;

using System.ComponentModel.DataAnnotations;
using NasSeminarski.Controllers;
using NasSeminarski.Models;

using NasSeminarski.Helper;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulDomar.Controllers
{
     [Autorizacija(KorisnickeUloge.Domar)]
    public class DomarController : Controller
    {
        // GET: ModulDomar/Domar


        MojContext db = new MojContext();
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi(int? sobaId)
        {
            var model = db.Inventari.ToList();
            return View(model);
        }
        public class UrediVM
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Naziv je obavezno polje")]
            public string Naziv { get; set; }
             [Required(ErrorMessage = "Opis je obavezno polje")]
            public string Opis { get; set; }
             [Required(ErrorMessage = "Cijena je obavezno polje")]
            public float Cijena { get; set; }
            public bool Upotrebljivo { get; set; }
            public List<SelectListItem> SobaStavke { get; set; }
            public List<SelectListItem> ZaposlenikStavke { get; set; }
            
            public int SobaId { get; set; }
           
            public int ZaposlenikId { get; set; }
        }



        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                Naziv = "",
                Opis = "",
                Cijena = 0,
                Upotrebljivo = false,
                SobaStavke = SobeStavke(),
                ZaposlenikStavke = ZaposlenikStavke()
            };
            return View("Uredi", model);
        }

        public ActionResult Uredi(int inventarID)
        {
            var x = db.Inventari.Find(inventarID);
            var model = new UrediVM
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis,
                Cijena = x.Cijena,
                Upotrebljivo = Convert.ToBoolean(x.Upotrebljivo),
                SobaId = x.SobaId,
                ZaposlenikId = x.ZaposlenikId,
                SobaStavke = SobeStavke(),
                
                ZaposlenikStavke = ZaposlenikStavke()
            };
            return View(model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Inventar x;
            if (!ModelState.IsValid)
            {
                model.ZaposlenikStavke = ZaposlenikStavke();
                model.SobaStavke = SobeStavke();

                return View("Uredi", model);

            }
            if (model.Id == 0)
            {
                x = new Inventar();
                db.Inventari.Add(x);
            }
            else
            {
                x = db.Inventari.Find(model.Id);
            }

            x.Naziv = model.Naziv;
            x.Opis = model.Opis;
            x.Cijena = model.Cijena;
            x.Upotrebljivo = model.Upotrebljivo;
            x.SobaId = model.SobaId;
            x.ZaposlenikId = model.ZaposlenikId;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }

        private List<SelectListItem> ZaposlenikStavke()
        {
            var zaposlenici = new List<SelectListItem>();
            zaposlenici.Add(new SelectListItem { Value = null, Text = "(ODABERITE ZAPOSLENIKA)" });


            var allZaposlenici = db.Zaposlenici.ToList();
            foreach (var item in allZaposlenici)
            {
                zaposlenici.Add(new SelectListItem { Value = item.Id.ToString(), Text = " ZAPOSLENIK: " + item.Korisnik.Ime + item.Korisnik.Prezime });
            }
            return zaposlenici;
        }

        private List<SelectListItem> SobeStavke()
        {
             var sobe = new List<SelectListItem>();
            sobe.Add(new SelectListItem { Value = null, Text = "(ODABERITE SOBU)" });


            var allSobe = db.Sobe.ToList();
            foreach (var item in allSobe)
            {
                sobe.Add(new SelectListItem { Value = item.Id.ToString(), Text = " SOBA BROJ: " + item.BrojSobe.ToString() });
            }
            return sobe;
        }
    }
}