using NasSeminarski.Areas.ModulUprava.Models;
using NasSeminarski.DAL;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulUprava.Controllers
{
       [Autorizacija( KorisnickeUloge.Upravnik)]
    public class ZaposlenikController : Controller
    {
        // GET: ModulUprava/Zaposlenik
        public ActionResult Index()
        {
            return View();
        }
        MojContext ctx = new MojContext();

        public ActionResult Prikazi(int? ulogaId, string search)
        {
            
            List<ZaposlenikPrikaziViewModel.ZaposlenikInfo> zaposlenikInfos = ctx.Zaposlenici
         
                .Where(x => (!ulogaId.HasValue || x.Korisnik.UlogeId == ulogaId ) && (x.IsDeleted==false) && (x.Korisnik.Ime.StartsWith(search) || search== null))
                .Select(x => new ZaposlenikPrikaziViewModel.ZaposlenikInfo()
                {
                    Ime = x.Korisnik.Ime,
                    Prezime= x.Korisnik.Prezime,
                    Id = x.Korisnik.Id,
                   Email = x.Korisnik.Email,
                    Kontakt = x.Korisnik.Kontakt,
                    DatumZaposlenja = x.Korisnik.Zaposlenik.DatumZaposlenja.Value,
           
                    UlogaNaziv= x.Korisnik.Uloge.Naziv
                    
                })
                .ToList();


            ZaposlenikPrikaziViewModel Model = new ZaposlenikPrikaziViewModel
            {
                zaposlenici = zaposlenikInfos,
                UlogeStavke = UcitajUloge()
            };

         
            return View("Prikazi", Model);
        }

        private List<SelectListItem> UcitajUloge()
        {
            var uloge = new List<SelectListItem>();
            uloge.Add(new SelectListItem { Value = null, Text = "(Odaberi ulogu)" });

            uloge.AddRange(ctx.Uloge.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }).Where(x => x.Text == "Domar" || x.Text == "Recepcioner" || x.Text == "Sobarica"
                || x.Text == "Računovođa" || x.Text == "Menadžer" || x.Text == "Upravnik").ToList());
            return uloge;
        }
        public ActionResult Dodaj()
        {
           ZaposlenikUrediViewModel Model = new ZaposlenikUrediViewModel();
           Model.UlogaStavke = UcitajUloge();


           return View("Uredi", Model);
        }

        public ActionResult Uredi(int Id)
        {
            Zaposlenik zaposlenik = ctx.Zaposlenici.Where(x => x.Id == Id).Include(x => x.Korisnik).Single();

            ZaposlenikUrediViewModel Model = new ZaposlenikUrediViewModel() 
            {
            
             Id = zaposlenik.Id,
            Ime = zaposlenik.Korisnik.Ime,
            DatumRodjenja = zaposlenik.Korisnik.DatumRodjenja,
            Prezime = zaposlenik.Korisnik.Prezime,
            Adresa = zaposlenik.Korisnik.Adresa,
            Email = zaposlenik.Korisnik.Email,
            Kontakt = zaposlenik.Korisnik.Kontakt,
            KorisnickoIme = zaposlenik.Korisnik.KorisnickoIme,
            Lozinka = zaposlenik.Korisnik.Lozinka,
            DatumZaposlenja = zaposlenik.DatumZaposlenja,
            OpisPosla = zaposlenik.OpisPosla,
            UlogaId = zaposlenik.Korisnik.UlogeId.Value,
            UlogaStavke = UcitajUloge()

            
            
            };
            
           
            return View("Uredi", Model);
        }
        public ActionResult Snimi(ZaposlenikUrediViewModel zaposlenik)
        {
            if (!ModelState.IsValid)
            {
               zaposlenik.UlogaStavke= UcitajUloge();
                return View("Uredi", zaposlenik);
            }

            Zaposlenik zaposlenikDB;
            if (zaposlenik.Id == 0)
            {
                zaposlenikDB = new Zaposlenik();
               zaposlenikDB.Korisnik = new Korisnik();
             
                ctx.Zaposlenici.Add(zaposlenikDB);
            }
            else
            {
                zaposlenikDB = ctx.Zaposlenici
                    .Where(s => s.Id == zaposlenik.Id)
                    .Include(s => s.Korisnik).FirstOrDefault();
            }

                zaposlenikDB.Korisnik.Ime = zaposlenik.Ime;
                zaposlenikDB.Korisnik.Prezime = zaposlenik.Prezime;
                zaposlenikDB.Korisnik.KorisnickoIme = zaposlenik.KorisnickoIme;
                zaposlenikDB.Korisnik.Lozinka = zaposlenik.Lozinka;
                zaposlenikDB.Korisnik.DatumRodjenja = zaposlenik.DatumRodjenja;
                zaposlenikDB.Korisnik.Adresa = zaposlenik.Adresa;
                zaposlenikDB.Korisnik.Email = zaposlenik.Email;
                zaposlenikDB.Korisnik.Kontakt = zaposlenik.Kontakt;
                zaposlenikDB.DatumZaposlenja = zaposlenik.DatumZaposlenja;
                zaposlenikDB.OpisPosla = zaposlenik.OpisPosla;
                zaposlenikDB.Korisnik.UlogeId= zaposlenik.UlogaId;

              
                ctx.SaveChanges();

            
            return RedirectToAction("Prikazi");
        }


        //public ActionResult Obrisi(int zId)
        //{
           
        //    ctx.Zaposlenici.Find(zId).IsDeleted = true;
        //    ctx.Korisnici.Find(zId).IsDeleted = true;
        //    ctx.SaveChanges();
          

        //    return RedirectToAction("Prikazi");
        //}



        public ActionResult Obrisi(int? zId)
        {
            if (zId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik zaposlenik = ctx.Korisnici.Find(zId);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int zId)
        {
             ctx.Korisnici.Find(zId).IsDeleted=true;
             ctx.Zaposlenici.Find(zId).IsDeleted = true;
     
            ctx.SaveChanges();
            return RedirectToAction("Prikazi");
        }

    }
}