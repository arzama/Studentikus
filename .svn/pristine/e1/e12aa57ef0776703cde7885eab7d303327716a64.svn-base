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
    public class TroskoviController : Controller
    {
        private MojContext db = new MojContext();
        // GET: ModulRacunovodja/Troskovi
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
            var model = db.Troskovi.ToList();
            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set;}
             [Required(ErrorMessage = "Svrha troska je obavezno polje")]
            public string svrhaTroska { get; set; }
            [Required(ErrorMessage = "Izos troska je obavezno polje")]
            public double iznosTroska { get; set; }
            [Required(ErrorMessage = "Rok isplate je obavezno polje")]
            public DateTime rokIsplate { get; set; }
            public bool uplaceno { get; set; }
        }

        public ActionResult Uredi(int trosakId)
        {
            var x = db.Troskovi.Find(trosakId);
            var model = new UrediVM
            {
                Id = x.id,
                svrhaTroska = x.svrhaTroska,
                iznosTroska = x.iznosTroska,
                rokIsplate = x.rokIsplate,
                uplaceno = x.uplaceno
            };
            return View(model);
        }
        public ActionResult Dodaj()
        {
            var model = new UrediVM
            {
                svrhaTroska = "",
                iznosTroska = 0,
                rokIsplate = DateTime.Now,
                uplaceno = false
            };
            return View("Uredi", model);
        }
        public ActionResult Snimi(UrediVM model)
        {
            Troskovi x;
            if(!ModelState.IsValid)
            {
                return View("Uredi", model);
            }

            if(model.Id==0)
            {
                x = new Troskovi();
                db.Troskovi.Add(x);
            }else
            {
                x = db.Troskovi.Find(model.Id);
            }

            x.svrhaTroska = model.svrhaTroska;
            x.iznosTroska = model.iznosTroska;
            x.rokIsplate = model.rokIsplate;
            x.uplaceno = model.uplaceno;
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }


    }
}