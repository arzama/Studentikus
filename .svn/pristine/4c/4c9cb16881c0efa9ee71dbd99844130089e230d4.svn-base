
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.DAL;
using NasSeminarski.Areas.ModulSobarica2.Models;
using System.Data.Entity;
using NasSeminarski;
using NasSeminarski.Areas;
using NasSeminarski.Controllers;
using NasSeminarski.Models;

using NasSeminarski.Helper;
using MVC.Helper;
namespace NasSeminarski.Areas.ModulSobarica2.Controllers
{
    public class Sobarica2Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        MojContext ctx = new MojContext();


        public ActionResult Dodaj()
        {
            SobaricaUrediViewModel model = new SobaricaUrediViewModel();
            model.SobeStavke = UcitajSobe();

         return View("Uredi", model);
        }

        public ActionResult Prikazi(int? sobaId,int? odrzavanjeId)
        {
            List<SobaricaPrikazi2ViewModel.OdrzavanjeInfo> odrzavanjeInfos = ctx.OdrzavanjeSoba

                  .Where(x => !sobaId.HasValue || x.Soba.Id == sobaId)
                  .Select(x => new SobaricaPrikazi2ViewModel.OdrzavanjeInfo()
                  {
                      Id = x.Id,
                 BrojSobe=x.Soba.BrojSobe,
                      Datum = x.Datum,
                      Komentar = x.Komentar,


                  })
                  .ToList();


            SobaricaPrikazi2ViewModel Model = new SobaricaPrikazi2ViewModel
            {
              
                odrzavanja = odrzavanjeInfos.Where(x=> !odrzavanjeId.HasValue || x.Id==odrzavanjeId  ).ToList(),
                SobeStavke = UcitajSobe(),
                DatumiStavke=UcitajDatume()
            };
            return View("Prikazi", Model);
        }
        private List<SelectListItem> UcitajSobe()
        {
            var sobe = new List<SelectListItem>();
            sobe.Add(new SelectListItem { Value = null, Text = "(Odaberi sobu)" });

            var allSobe = ctx.Sobe.ToList();
            foreach (var item in allSobe)
            {
                sobe.Add(new SelectListItem { Value = item.Id.ToString(), Text = " " + item.BrojSobe });
            }
           
            return sobe;
        }

        private List<SelectListItem> UcitajDatume()
        {
            var datumi = new List<SelectListItem>();
            datumi.Add(new SelectListItem { Value = null, Text = "(Odaberite datum)" });
            var sviDatumi = ctx.OdrzavanjeSoba.ToList();
            foreach (var item in sviDatumi)
            {
                datumi.Add(new SelectListItem { Value = item.Id.ToString(), Text = " " + item.Datum });
            }
          
            return datumi;
        }

        public ActionResult Snimi(SobaricaUrediViewModel odrzavanje)
        {
            if (!ModelState.IsValid)
            {
                odrzavanje.SobeStavke = UcitajSobe();
                return View("Uredi", odrzavanje);
            }
            OdrzavanjeSobe odrzavanjeDB;
            Korisnik korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            if (odrzavanje.Id == 0)
            {
                odrzavanjeDB = new OdrzavanjeSobe();
                odrzavanjeDB.Zaposlenik = ctx.Zaposlenici.Find(korisnik.Id);
         
                odrzavanjeDB.Soba = ctx.Sobe.Where(x => x.Id == odrzavanje.SobaId).FirstOrDefault();


                ctx.OdrzavanjeSoba.Add(odrzavanjeDB);
            }

            else
            {

                odrzavanjeDB = ctx.OdrzavanjeSoba.Where(o => o.Id == odrzavanje.Id).Include(o => o.Zaposlenik).Include(o => o.Soba)
                    .FirstOrDefault();
            }
         
            odrzavanjeDB.Datum = odrzavanje.Datum;
            odrzavanjeDB.ZaposlenikId = korisnik.Id;
            odrzavanjeDB.Komentar = odrzavanje.Komentar;

            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }

        public ActionResult Uredi(int? odrzavanjeId)
        {

              OdrzavanjeSobe odrzavanje = ctx.OdrzavanjeSoba
                  .Where(x => x.Id == odrzavanjeId)
                  .Include(x=> x.Soba)
                  .Single();

              SobaricaUrediViewModel Model = new SobaricaUrediViewModel()
                {
                    
                    Id = odrzavanje.Id,
                    Datum= odrzavanje.Datum, 
                SobaId=odrzavanje.SobaId,
                SobeStavke=UcitajSobe(),
                    Komentar=odrzavanje.Komentar,
                ZaposlenikId=odrzavanje.ZaposlenikId



            };


            return View("Uredi", Model);

        }


        public ActionResult Obrisi(int Id)
        {
           OdrzavanjeSobe x = ctx.OdrzavanjeSoba.Find(Id);
            ctx.OdrzavanjeSoba.Remove(x);
            ctx.SaveChanges();
            return RedirectToAction("Prikazi");
        }
       

    }


}



