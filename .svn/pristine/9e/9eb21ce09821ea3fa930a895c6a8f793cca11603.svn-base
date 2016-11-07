using MVC.Helper;
using NasSeminarski.DAL;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava.Controllers
{
    [Autorizacija(KorisnickeUloge.Upravnik)]
    public class UgovorController : Controller
    {
        MojContext ctx = new MojContext();
        public class IndexVM
        {

            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public int BrojKartice { get; set; }
            public string StudentIme{get; set;}
          public string StudentPrezime{get; set;}
          public int BrojSobe { get; set; }
          public string Godina { get; set; }
        }

        // GET: ModulUprava/Ugovor
        public ActionResult Index()
        {
           

            var model = ctx.UgovoriOStanovanju.Where(x=>x.IsDeleted==false).Select(x => new IndexVM
            {
                Id=x.Id,
                 BrojKartice=x.BrojKartice,
                  Datum=x.Datum.Value,
                 BrojSobe=ctx.Sobe.Where(y=>y.Id==x.SobaId).FirstOrDefault().BrojSobe,
                  Godina=ctx.SkolskeGodine.Where(y=>y.Id==x.SkolskaGodinaId).FirstOrDefault().AkademskaGodina,
                   StudentIme=ctx.Studenti.Where(y=>y.Id==x.StudentId).FirstOrDefault().Korisnik.Ime,
                      StudentPrezime=ctx.Studenti.Where(y=>y.Id==x.StudentId).FirstOrDefault().Korisnik.Prezime
               
            }).ToList();


            return View(model);
        }

        public class UrediVM
        {
            public int Id { get; set; }
            public DateTime? Datum { get; set; }
            public int BrojKartice { get; set; }
            public int? SkolskaGodinaId { get; set; }
            public int? SobaId { get; set; }
            public int? StudentId { get; set; }
            public List<SelectListItem> SkolskaGodinaStavke { get; set; }
            public List<SelectListItem> SobaStavke { get; set; }
            public List<SelectListItem> StudentStavke { get; set; }
        
        }

        private List<SelectListItem> UcitajSkolskeGodine()
        {
            var godine = new List<SelectListItem>();
            godine.Add(new SelectListItem { Value = null, Text = "(Odaberi školsku godinu)" });

            var allGodine = ctx.SkolskeGodine.ToList();
            foreach (var item in allGodine)
            {
                godine.Add(new SelectListItem { Value = item.Id.ToString(), Text = " " + item.AkademskaGodina });
            }
            return godine;
        }


        private List<SelectListItem> UcitajStudente()
        {
            var studenti = new List<SelectListItem>();
            studenti.Add(new SelectListItem { Value = null, Text = "(Odaberi studenta)" });

            studenti.AddRange(ctx.Studenti.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Korisnik.Ime+" "+x.Korisnik.Prezime
            }).ToList());
            return studenti;
        }


        private List<SelectListItem> UcitajSobe()
        {
            var sobe = new List<SelectListItem>();
            sobe.Add(new SelectListItem { Value = null, Text = "(Odaberi sobu)" });

   
            var allSobe = ctx.Sobe.ToList();
            foreach (var item in allSobe)
            {
                sobe.Add(new SelectListItem { Value = item.Id.ToString(), Text = " broj sobe: " + item.BrojSobe });
            }
            return sobe;
        }


        public ActionResult Uredi(int Id)
        {
            var x = ctx.UgovoriOStanovanju.Find(Id);
            var model = new UrediVM
            {
               
                Id = x.Id,
                 BrojKartice=x.BrojKartice,
                 
                  Datum=x.Datum.Value,
                   SkolskaGodinaId=x.SkolskaGodinaId.Value, 
                    SobaId=x.SobaId.Value,
                     StudentId=x.StudentId.Value,
                    SkolskaGodinaStavke=UcitajSkolskeGodine(),
                     SobaStavke=UcitajSobe(),
                      StudentStavke=UcitajStudente()
            

            };
            return View("Uredi", model);

        }

        public ActionResult Dodaj()
        {
            UrediVM model = new UrediVM();
            model.SkolskaGodinaStavke = UcitajSkolskeGodine();
            model.StudentStavke = UcitajStudente();
            model.SobaStavke = UcitajSobe();
       

            return View("Uredi", model);
        }

        public ActionResult Snimi(UrediVM model)
        {
          
            if (!ModelState.IsValid)
            {
                model.StudentStavke=UcitajStudente();
                model.SkolskaGodinaStavke = UcitajSkolskeGodine();
                model.SobaStavke = UcitajSobe();
                return View("Uredi", model);

            }
            UgovorOStanovanju x;
            if (model.Id == 0)
            {
                x = new UgovorOStanovanju();
              
                
                //x.Student = ctx.Studenti.Where(y => y.Id == model.StudentId).FirstOrDefault();
                //x.Soba = ctx.Sobe.Where(y => y.Id == model.SobaId).FirstOrDefault();
                //x.SkolskaGodina = ctx.SkolskeGodine.Where(y => y.Id == model.SkolskaGodinaId).FirstOrDefault();
   

                ctx.UgovoriOStanovanju.Add(x);
            }
            else
            {
                x = ctx.UgovoriOStanovanju.Where(o => o.Id == model.Id).FirstOrDefault();
            }

            x.StudentId = model.StudentId;
            x.SobaId = model.SobaId;
            x.SkolskaGodinaId = model.SkolskaGodinaId;
          
            x.Datum = model.Datum.Value;
            x.BrojKartice = model.BrojKartice;
           
           
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}