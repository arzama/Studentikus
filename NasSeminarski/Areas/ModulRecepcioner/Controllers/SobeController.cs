using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.DAL;
using NasSeminarski.Areas.ModulRecepcioner.Models;
using NasSeminarski.Models;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
    [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class SobeController : Controller
    {
        
        private MojContext db = new MojContext();
        // GET: ModulRecepcioner/Sobe
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Prikazi()
        {
                 var model = db.Sobe.ToList();
                 return View(model);
        }

     
  public class UrediVM2
  {
      public int Id { get; set; }
      public DateTime Datumprijave { get; set; }
      public DateTime DatumOdjave { get; set; }
      public bool Realizovana { get; set; }
      public bool otkazana { get; set; }
      public List<SelectListItem> SobaStavke{get; set;}
      public int sobaId { get; set; }
      public List<SelectListItem> KorisnikStavke { get; set; }
      public int KorisnikId { get; set; }

  }

        public ActionResult DodajRezervaciju()
        {
            var model = new UrediVM2
            {
                Datumprijave = DateTime.Now,
                DatumOdjave = DateTime.Now,
                Realizovana = false,
                otkazana = false,
                SobaStavke = SobaStavke(),
                KorisnikStavke = KorisnikStavke()
            };
            return View("Uredi", model);
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

        private List<SelectListItem> KorisnikStavke()
        {
            var korisnik = new List<SelectListItem>();
            korisnik.Add(new SelectListItem { Value = null, Text = "(ODABERITE KORISNIKA)" });


            var allKorisnici = db.Korisnici.ToList();
            foreach (var item in allKorisnici)
            {
                korisnik.Add(new SelectListItem { Value = item.Id.ToString(), Text = " KORISNIK: " + item.Ime + item.Prezime });
            }
            return korisnik;
        }

    }
}