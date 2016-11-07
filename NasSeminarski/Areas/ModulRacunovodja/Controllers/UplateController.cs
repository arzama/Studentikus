using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;

using System.ComponentModel.DataAnnotations;
using NasSeminarski.DAL;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulRacunovodja.Controllers
{
    [Autorizacija(KorisnickeUloge.Racunovodja)]
    public class UplateController : Controller
    {
        private MojContext db = new MojContext();
        // GET: ModulRacunovodja/Uplate
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.Uplate.ToList();
            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
             [Required(ErrorMessage = "Datum uplate je obavezno polje")]
            public DateTime Datum { get; set; }
             [Required(ErrorMessage = "Iznos uplate je obavezno polje")]
            public double IznosUplate { get; set; }
             [Required(ErrorMessage = "Svrha uplate je obavezno polje")]
            public string svrhaUplate { get; set; }
            public List<SelectListItem> StudentStavka { get; set; }
           
            public int studentId { get; set; }
        }

        public ActionResult Uredi(int uplataId)
        {
            var x = db.Uplate.Find(uplataId);
            var model = new UrediVM
            {
                Id = x.Id,
                Datum = x.DatumUplate,
                IznosUplate = x.IznosUplate,
                svrhaUplate = x.svrhaUplate,
                StudentStavka = StudentStavka(),
                studentId = x.studentId
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                Datum = DateTime.Now,
                IznosUplate = 0,
                svrhaUplate = "",
                StudentStavka = StudentStavka()
            };
            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Uplata x;
            if(!ModelState.IsValid)
            {
                model.StudentStavka = StudentStavka();
                return View("Uredi", model);
            }
            if(model.Id==0)
            {
                x = new Uplata();
                db.Uplate.Add(x);
            }else
            {
                x = db.Uplate.Find(model.Id);
            }
            x.DatumUplate = model.Datum;
            x.IznosUplate = model.IznosUplate;
            x.svrhaUplate = model.svrhaUplate;
            x.studentId = model.studentId;
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
                studenti.Add(new SelectListItem { Value = item.Id.ToString(), Text = " STUDENT: " + item.Korisnik.Ime + item.Korisnik.Prezime });
            }
            return studenti;
        }
    }
}