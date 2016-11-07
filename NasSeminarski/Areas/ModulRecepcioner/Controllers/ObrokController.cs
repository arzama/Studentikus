using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.DAL;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
     [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class ObrokController : Controller
    {
       
        private MojContext db = new MojContext();
        // GET: ModulRecepcioner/Obrok
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Prikazi()
        {
            var model = db.EvidencijaObroka.ToList();
            return View(model);
        }
        public class UrediVM
        {
            public int Id { get; set; }
 [Required(ErrorMessage = "Datum je obavezno polje")]
            public DateTime Datum { get; set; }
            public List<SelectListItem> StudentStavka { get; set; }
            public int studentId { get; set; }
            public bool uplaceno { get; set; }
            [Required(ErrorMessage = "Broj obroka je obavezno polje")]
            public int BrojObroka { get; set; }


        }
        public ActionResult Uredi(int obrokId)
        {
            var x = db.EvidencijaObroka.Find(obrokId);
            var model = new UrediVM
            {
                Id = x.Id,
                Datum = Convert.ToDateTime(x.Datum),
                StudentStavka = StudentStavka(),
                studentId = Convert.ToInt32(x.studentId),
                uplaceno = Convert.ToBoolean(x.Uplaceno),
                BrojObroka = Convert.ToInt32(x.BrojObroka)
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                Datum = DateTime.Now,
                StudentStavka = StudentStavka(),
                uplaceno = false,
                BrojObroka = 0
            };
            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            EvidencijaObroka x;

            if (!ModelState.IsValid)
            {
                model.StudentStavka = StudentStavka();

                return View("Uredi", model);

            }
            if (model.Id == 0)
            {
                x = new EvidencijaObroka();
                db.EvidencijaObroka.Add(x);
            }
            else
            {
                x = db.EvidencijaObroka.Find(model.Id);
            }
            x.Datum = model.Datum;
            x.studentId = model.studentId;
            x.Uplaceno = model.uplaceno;
            x.BrojObroka = model.BrojObroka;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }

        private List<SelectListItem> StudentStavka()
        {
            var studenti = new List<SelectListItem>();
            studenti.Add(new SelectListItem { Value = null, Text = "(ODABERITE STUDENTA)" });


            var allStudenti = db.Studenti.ToList();
            foreach (var item in allStudenti)
            {
                studenti.Add(new SelectListItem { Value = item.Id.ToString(), Text = " STUDENT: " + item.Korisnik.Ime+item.Korisnik.Prezime });
            }
            return studenti;
        }
    }
}