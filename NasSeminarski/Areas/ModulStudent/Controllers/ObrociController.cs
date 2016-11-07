using MVC.Helper;
using NasSeminarski.DAL;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Models;
using NasSeminarski.Controllers;
using System.Data.Entity;

namespace NasSeminarski.Areas.ModulStudent.Controllers
{
    [Autorizacija(KorisnickeUloge.Upravnik)]
    public class ObrociController : Controller
    {
        public MojContext ctx = new MojContext();

       
        public class IndexVM
        {
            public class ObrokInfo
            {
                public int Id { get; set; }
                public DateTime Datum { get; set; }
                public DateTime Vrijeme { get; set; }
                
          
            }
            public List<ObrokInfo> obroci { get; set; }
            public List<SelectListItem> MjesecStavke { get; set; }
            public int MjesecId { get; set; }
            public int brojPreostalih { get; set; }
            public int brojPotrosenih { get; set; }
            public int BrojKartice { get; set; }
        }

        private List<SelectListItem> UcitajMjesec()
        {
      

            var mjesec = new List<SelectListItem>();
            mjesec.Add(new SelectListItem { Value = "13", Text = "(Odaberi mjesec)" });
            mjesec.Add(new SelectListItem { Value = "10", Text = "Oktobar" });
            mjesec.Add(new SelectListItem { Value = "11", Text = "Novembar" });
            mjesec.Add(new SelectListItem { Value = "12", Text = "Decembar" });
            mjesec.Add(new SelectListItem { Value = "1", Text = "Januar" });
            mjesec.Add(new SelectListItem { Value = "2", Text = "Februar" });
            mjesec.Add(new SelectListItem { Value = "3", Text = "Mart" });
            mjesec.Add(new SelectListItem { Value = "4", Text = "April" });
            mjesec.Add(new SelectListItem { Value = "5", Text = "Maj" });
            mjesec.Add(new SelectListItem { Value = "6", Text = "Juni" });
           
            return mjesec;
        }


        public ActionResult Index(int? MjesecId)
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            List<IndexVM.ObrokInfo> obrokInfos = ctx.EvidencijaObroka.Where(x => x.IsDeleted == false && x.UgovorOStanovanju.StudentId==k.Id && x.MjesecObracun.Mjesec==MjesecId ).Select(x => new IndexVM.ObrokInfo()
            {

                Id = x.Id,
                Datum = x.Datum.Value,
                
                  //BrojKartice = ctx.UgovoriOStanovanju.Where(y => y.Id == x.UgovorOStanovanjuId).FirstOrDefault().BrojKartice
  

            }).ToList();


            IndexVM model = new IndexVM
            {
                obroci = obrokInfos,
                 MjesecStavke=UcitajMjesec(),
                brojPotrosenih = ctx.EvidencijaObroka.Where(s => s.IsDeleted == false && s.UgovorOStanovanju.StudentId == k.Id && s.MjesecObracun.Mjesec == MjesecId).Count(),
                brojPreostalih = 30 - ctx.EvidencijaObroka.Where(s => s.IsDeleted == false && s.UgovorOStanovanju.StudentId == k.Id && s.MjesecObracun.Mjesec == MjesecId).Count(),
              
             BrojKartice= ctx.UgovoriOStanovanju.Where(y=>y.StudentId==k.Id).FirstOrDefault().BrojKartice
            };

           


            return View(model);
        }


    }
}