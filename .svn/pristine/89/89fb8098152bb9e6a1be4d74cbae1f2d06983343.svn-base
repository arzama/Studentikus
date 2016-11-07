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
    public class DesavanjaController : Controller
    {
        // GET: ModulUprava/Desavanja
        public ActionResult Index()
        {
            return View("Index");
        }

        MojContext ctx = new MojContext();

        public class PrikaziVM
        { 
            public class DesavanjaInfo{
            //public Desavanja Desavanja { get; set; }
            //public Korisnik Korisnik { get; set; }
                public int Id { get; set; }
                public string Nazv { get; set; }
                public DateTime Datum { get; set; }
                public string Opis { get; set; }
                public string KorisnikIme { get; set; }
                public string KorisnikPrezime { get; set; }
                public string Telefon { get; set; }
                public string ZaposlenikIme { get; set; }
                public string ZaposlenikPrezime { get; set; }
            }
            public List<DesavanjaInfo> desavanja;
            public int broj { get; set; }
     
        }


        public ActionResult Prikazi()
        {
            PrikaziVM Model =  new PrikaziVM
            {
               
                broj = ctx.Desavanja.Where(y => y.Datum < DateTime.Now).Count(),
       
                desavanja = ctx.Desavanja.Where(y=>y.Datum<DateTime.Now)
                                        .Select(y => new PrikaziVM.DesavanjaInfo
                                                {
                                                    Id=y.Id,
                                                    Nazv=y.Naziv,
                                                     Datum=y.Datum.Value,
                                                      Opis=y.Opis,
                                                       KorisnikIme=y.Ime,
                                                        KorisnikPrezime=y.Prezime,
                                                         Telefon=y.BrojTelefona,
                                                          ZaposlenikIme=ctx.Korisnici.Where(z => z.Id == y.ZaposlenikId).FirstOrDefault().Ime,
                                                           ZaposlenikPrezime=ctx.Korisnici.Where(z => z.Id == y.ZaposlenikId).FirstOrDefault().Prezime,
                                                  
                                                }).ToList(),



            };



            return View("Prikazi", Model);

        }


        public ActionResult PrikaziSlijedeca()
        {
            PrikaziVM Model = new PrikaziVM
            {

                broj = ctx.Desavanja.Where(y => y.Datum > DateTime.Now).Count(),
                desavanja = ctx.Desavanja.Where(y => y.Datum > DateTime.Now)
                                        .Select(y => new PrikaziVM.DesavanjaInfo
                                        {
                                            Id = y.Id,
                                            Nazv = y.Naziv,
                                            Datum = y.Datum.Value,
                                            Opis = y.Opis,
                                            KorisnikIme = y.Ime,
                                            KorisnikPrezime = y.Prezime,
                                            Telefon = y.BrojTelefona,
                                            ZaposlenikIme = ctx.Korisnici.Where(z => z.Id == y.ZaposlenikId).FirstOrDefault().Ime,
                                            ZaposlenikPrezime = ctx.Korisnici.Where(z => z.Id == y.ZaposlenikId).FirstOrDefault().Prezime,

                                        }).ToList(),



            };

         

            return View("PrikaziSlijedeca", Model);

        }



        public ActionResult Detalji(int Id)
        {
            Desavanja Model = ctx.Desavanja.Find(Id);
            Model.Zaposlenik = ctx.Zaposlenici.Find(Model.ZaposlenikId);
            Model.Zaposlenik.Korisnik = ctx.Korisnici.Find(Model.ZaposlenikId);
           
            return View(Model);
        }

    }
}