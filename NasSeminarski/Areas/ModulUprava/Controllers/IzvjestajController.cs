using NasSeminarski.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava.Controllers
{
    public class IzvjestajController : Controller
    {
        public MojContext ctx = new MojContext();

        public class IndexVM
        {
            public class IzvjestajInfo
            {

                
                public int Mjesec { get; set; }
               
                public int RacunId { get; set; }
                public string ZaposlenikIme { get; set; }
                public string ZaposlenikPrezime { get; set; }
                public int? StudentId { get; set; }
                public string StudentIme { get; set; }
                public string StudentPrezime { get; set; }
                public string KantonNaziv { get; set; }
                public string Fakultet { get; set; }
                public string Adresa { get; set; }
            }
            public List<IzvjestajInfo> izvjestaji;
            public List<SelectListItem> MjesecObracunaStavke { get; set; }
            public int MjesecObracunaId { get; set; }
            public List<SelectListItem> KantonStavke { get; set; }
            public int KantonId { get; set; }
            public int broj { get; set; }

        }


        // GET: ModulUprava/Izvjestaj
        public ActionResult Index(int? MjesecObracunaId, int? KantonId)
        {
            List<IndexVM.IzvjestajInfo> izvjestajInfos = ctx.Racuni
                .Where(x=>x.UgovorOStanovanju.Student.IsDeleted==false)
                .Where(x => (!MjesecObracunaId.HasValue || x.MjesecObracun.Id == MjesecObracunaId) && (x.UgovorOStanovanju.Student.KantonId == KantonId  || !KantonId.HasValue))
                .Select(x => new IndexVM.IzvjestajInfo()
            {
                StudentPrezime = ctx.UgovoriOStanovanju.Where(y => y.Id == x.UgovorOStanovanjuId).FirstOrDefault().Student.Korisnik.Prezime,
                 ZaposlenikPrezime=x.Zaposlenik.Korisnik.Prezime,
                 Mjesec = x.MjesecObracunId.Value,
                 StudentId = ctx.UgovoriOStanovanju.Where(y => y.Id == x.UgovorOStanovanjuId).FirstOrDefault().StudentId,
                StudentIme = ctx.UgovoriOStanovanju.Where(y => y.Id == x.UgovorOStanovanjuId ).FirstOrDefault().Student.Korisnik.Ime,
                RacunId = x.Id,
                ZaposlenikIme = x.Zaposlenik.Korisnik.Ime,
                Adresa = ctx.UgovoriOStanovanju.Where(y => y.Id == x.UgovorOStanovanjuId).FirstOrDefault().Student.Korisnik.Adresa,
                 Fakultet=ctx.UgovoriOStanovanju.Where(y => y.Id == x.UgovorOStanovanjuId ).FirstOrDefault().Student.Fakultet,
                 KantonNaziv=ctx.UgovoriOStanovanju.Where(y=>y.Id==x.UgovorOStanovanjuId).FirstOrDefault().Student.Kanton.Naziv
                  


            }).ToList();

            IndexVM model = new IndexVM
            {
                izvjestaji = izvjestajInfos,
              MjesecObracunaStavke= UcitajMjesecObracuna(),
               KantonStavke=UcitajKantone(),
               broj= ctx.Racuni
                .Where(x=>x.UgovorOStanovanju.Student.IsDeleted==false)
                .Where(x => (!MjesecObracunaId.HasValue || x.MjesecObracun.Id == MjesecObracunaId) && (x.UgovorOStanovanju.Student.KantonId == KantonId  || !KantonId.HasValue)).Count()
               
            };



            return View(model);
        }


        private List<SelectListItem> UcitajMjesecObracuna()
        {
            var mjesec = new List<SelectListItem>();
            mjesec.Add(new SelectListItem { Value = null, Text = "(Odaberi mjesec)" });

            var allMjesec = ctx.MjeseciObracuna.ToList();
            foreach (var item in allMjesec)
            {
                mjesec.Add(new SelectListItem { Value = item.Id.ToString(), Text = " " + item.Mjesec + "/" + item.Godina + "god." });
            }
            return mjesec;
        }

        private List<SelectListItem> UcitajKantone()
        {
            var kanton = new List<SelectListItem>();
            kanton.Add(new SelectListItem { Value = null, Text = "(Odaberi kanton)" });

            var allKanton = ctx.Kantoni.ToList();
            foreach (var item in allKanton)
            {
                kanton.Add(new SelectListItem { Value = item.Id.ToString(), Text = " " + item.Naziv });
            }
            return kanton;
        }


    }
}