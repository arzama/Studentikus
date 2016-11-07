using MVC.Helper;
using NasSeminarski.Areas.ModulUprava.Models;
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
    public class UlogaController : Controller
    {
        // GET: ModulUprava/Uloga
        public ActionResult Index()
        {
            return View("Index");
        }
        MojContext ctx = new MojContext();

        public class PrikaziVM
        {
            public Uloge Uloge { get; set; }
            public int broj { get; set; }
        
        }
        public ActionResult Prikazi()
        {
            var model = ctx.Uloge.Select(x => new PrikaziVM
            {
                Uloge = x,
                broj= ctx.Korisnici.Where(y=>y.UlogeId==x.Id && y.IsDeleted==false).Count()
            }).ToList();

            return View("Prikazi", model);

        }


        public ActionResult Dodaj()
        {

            var model = new UrediVM
            {
                


            };



            return View("Uredi", model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Naziv uloge obavezno unijeti !")]
            public string Naziv { get; set; }
            public string Opis { get; set; }
        }
        public ActionResult Uredi(int ulogaId)
        {
             var x = ctx.Uloge.Find(ulogaId);
             var model = new UrediVM
             {
                 Naziv = x.Naziv,
                 Opis = x.Opis,
                 Id = x.Id,

             };
            

            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
            Uloge x;
            if (!ModelState.IsValid)
            {
                return View("Uredi", model);

            }
            if (model.Id == 0)
            {
                x = new Uloge();
                ctx.Uloge.Add(x);
            }
            else
            {
                x = ctx.Uloge.Find(model.Id);

            }

            x.Naziv = model.Naziv;
            x.Opis = model.Opis;
          
             ctx.SaveChanges();

            return RedirectToAction("Prikazi");

        }
  
       
    }
}