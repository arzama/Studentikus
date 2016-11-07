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
    public class KljucController : Controller
    {
         

        private MojContext db = new MojContext();
        // GET: ModulRecepcioner/Kljuc
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.Kljucevi.ToList();
            return View(model);
        }
        public class UrediVM
        {
            public int Id { get; set; }
                [Required(ErrorMessage = "Broj ključa je obavezno polje")]
            public int BrojKljuca { get; set; }
                [Required(ErrorMessage = "Kolicina je obavezno polje")]
            public int Kolicina { get; set; }
            public List<SelectListItem> SobaStavke { get; set; }
            public int SobaId { get; set; }
        }

        public ActionResult Uredi(int kljucId)
        {
            var x = db.Kljucevi.Find(kljucId);
            var model = new UrediVM
            {
                Id = x.Id,
                BrojKljuca = x.BrojKljuca,
                Kolicina = x.Kolicina,
                SobaId = x.SobaId,
                SobaStavke = SobaStavke()
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                BrojKljuca = 0,
                Kolicina = 0,
                SobaStavke = SobaStavke()
            };
            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Kljuc x;
            if (!ModelState.IsValid)
            {
                model.SobaStavke = SobaStavke();

                return View("Uredi", model);

            }

            if(model.Id==0)
            {
                x = new Kljuc();
                db.Kljucevi.Add(x);
            }
            else
            {
                x = db.Kljucevi.Find(model.Id);
            }

            x.BrojKljuca = model.BrojKljuca;
            x.Kolicina = model.Kolicina;
            x.SobaId = model.SobaId;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
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
    }
}
