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
    public class PlataController : Controller
    {
        private MojContext db = new MojContext();
        // GET: ModulRacunovodja/Plata
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.Plate.ToList();
            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
             [Required(ErrorMessage = "Iznos plate je obavezno polje")]
            public double iznosPlate { get; set; }
             [Required(ErrorMessage = "Datum je obavezno polje")]
            public DateTime RokIsplate { get; set; }
            public bool Isplaceno { get; set; }
            public List<SelectListItem> ZaposlenikStavka { get; set; }
            public int ZaposlenikId { get; set; }
        }

        public ActionResult Uredi(int plataId)
        {
            var x = db.Plate.Find(plataId);
            var model = new UrediVM
            {
                Id = x.Id,
                iznosPlate = x.IznosPlate,
                RokIsplate = x.RokIsplate,
                Isplaceno = x.Isplaceno,
                ZaposlenikId = x.ZaposlenikId,
                ZaposlenikStavka = ZaposlenikStavka()

            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
                {
                    iznosPlate = 0,
                    RokIsplate = DateTime.Now,
                    Isplaceno = false,
                    ZaposlenikStavka = ZaposlenikStavka()
                };
            return View("Uredi", model);
        
        }

        public ActionResult Snimi(UrediVM model)
        {
            Plata x; 
             if (!ModelState.IsValid)
            {
                model.ZaposlenikStavka = ZaposlenikStavka();

                return View("Uredi", model);

            }


            if(model.Id==0)
            {
                x = new Plata();
                db.Plate.Add(x);
            }else
            {
                x = db.Plate.Find(model.Id);
            }
            x.RokIsplate = model.RokIsplate;
            x.IznosPlate = model.iznosPlate;
            x.Isplaceno = model.Isplaceno;
            x.ZaposlenikId = model.ZaposlenikId;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }

        private List<SelectListItem> ZaposlenikStavka()
        {
               var zaposlenici = new List<SelectListItem>();
               zaposlenici.Add(new SelectListItem { Value = null, Text = "(ODABERITE ZAPOSLENIKA)" });


            var allZaposlenici = db.Zaposlenici.ToList();
            foreach (var item in allZaposlenici)
            {
                zaposlenici.Add(new SelectListItem { Value = item.Id.ToString(), Text = " ZAPOSLENIK: " + item.Korisnik.Ime + item.Korisnik.Prezime});
            }
            return zaposlenici;
        }
    }
}