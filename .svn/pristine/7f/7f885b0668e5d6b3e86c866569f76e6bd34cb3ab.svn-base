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


namespace NasSeminarski.Areas.ModulUprava.Controllers
{
    [Autorizacija(KorisnickeUloge.Upravnik)]
    public class StudentController : Controller
    {
        public MojContext ctx= new MojContext();

        public class UrediVM
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Naziv fakulteta je obavezno polje!")]
            public string Fakultet { get; set; }
            [DataType(DataType.Date)]
            public DateTime DatumUseljenja { get; set; }
      
            [Required(ErrorMessage = "Ime studenta je obavezno polje!")]
            public string Ime { get; set; }
             [Required(ErrorMessage = "Prezime studenta je obavezno polje!")]
            public string Prezime { get; set; }
             [DataType(DataType.Date)]
            public DateTime DatumRodjenja { get; set; }
            public string Adresa { get; set; }
            [Required(ErrorMessage = "E-mail adresa je obavezno polje!")]
            [EmailAddress]
            public string Email { get; set; }
             [Required(ErrorMessage = "Kontakt telefon je obavezno polje!")]
            public string Kontakt { get; set; }
             [Required(ErrorMessage = "Korisnicko ime je obavezno polje!")]
            public string KorisnickoIme { get; set; }
            [Required(ErrorMessage = "Lozinka je obavezno polje!")]
            public string Lozinka { get; set; }

            public int KantonId { get; set; }
            public List<SelectListItem> KantonStavke { get; set; }
        }

        public class IndexVM
        {
            public class StudentInfo
            {
                public int Id { get; set; }
                public string Fakultet { get; set; }
                public DateTime DatumUseljenja { get; set; }
                public string Ime { get; set; }
                public string Prezime { get; set; }
                public DateTime DatumRodjenja { get; set; }
                public string Adresa { get; set; }
                public string Email { get; set; }
                public string Kontakt { get; set; }
                public string KorisnickoIme { get; set; }
                public string Lozinka { get; set; }

                public string Kanton { get; set; }
            }
            public List<StudentInfo> studenti { get; set; }
   
        }

        // GET: ModulUprava/Student
        public ActionResult Index()
        {
         
            List<IndexVM.StudentInfo> studentInfos = ctx.Studenti.Where(x=>x.IsDeleted==false).Select(x => new IndexVM.StudentInfo()
            {
                
                 Id=x.Id,
                 Kanton=x.Kanton.Naziv,
                  Fakultet=x.Fakultet,
                   Ime=x.Korisnik.Ime,
                    Prezime=x.Korisnik.Prezime,
                     Kontakt=x.Korisnik.Kontakt,
                      KorisnickoIme=x.Korisnik.KorisnickoIme
                   

            }).ToList();


            IndexVM model = new IndexVM
            {
                studenti = studentInfos
              
            };
            
            return View(model);
        }

        public ActionResult Dodaj()
        {
            UrediVM Model = new UrediVM();
            Model.KantonStavke = UcitajKanton();
            return View("Uredi", Model);
        }

        public ActionResult Obrisi(int studentId)
        {

            ctx.Studenti.Find(studentId).IsDeleted = true;
            ctx.Korisnici.Find(studentId).IsDeleted = true;
            //ctx.Racuni.Where(x => x.UgovorOStanovanju.StudentId == studentId).FirstOrDefault().IsDeleted = true;
            //ctx.UgovoriOStanovanju.Where(x => x.StudentId == studentId).FirstOrDefault().IsDeleted = true;
            ctx.SaveChanges();


            return RedirectToAction("Index");
        }

       



        public ActionResult Uredi(int studentID)
        {

             
            Student x = ctx.Studenti.Where(y=>y.Id==studentID).Include(y=>y.Korisnik).FirstOrDefault();
            var model = new UrediVM
            {

                Id = x.Id,
                DatumUseljenja = x.DatumUseljenja.Value,
                DatumRodjenja = x.Korisnik.DatumRodjenja.Value,
                KantonStavke = UcitajKanton(),
                KantonId = x.KantonId.Value,
                Fakultet = x.Fakultet,
                Lozinka = x.Korisnik.Lozinka,
                KorisnickoIme = x.Korisnik.KorisnickoIme,
                Kontakt = x.Korisnik.Kontakt,
                Email = x.Korisnik.Email,
                Adresa = x.Korisnik.Adresa,
                Prezime = x.Korisnik.Prezime,
                Ime = x.Korisnik.Ime



            };

            return View("Uredi", model);
        }


        public ActionResult Snimi(UrediVM student)
        {
            if (!ModelState.IsValid)
            {
                student.KantonStavke = UcitajKanton();
                return View("Uredi", student);
            }
            Student studentDB;
            if (student.Id == 0)
            {
                studentDB = new Student();
                studentDB.Korisnik = new Korisnik();
                studentDB.Korisnik.UlogeId = 9;
                ctx.Studenti.Add(studentDB);

            }

            else
            {
                studentDB = ctx.Studenti.Where(x => x.Id == student.Id).Include(x=>x.Korisnik).FirstOrDefault();

            }

            studentDB.Fakultet = student.Fakultet;
            studentDB.Korisnik.Ime = student.Ime;
            studentDB.Korisnik.Prezime = student.Prezime;
            studentDB.Korisnik.DatumRodjenja = student.DatumRodjenja;
            studentDB.Korisnik.Adresa = student.Adresa;
            studentDB.Korisnik.Email = student.Email;
            studentDB.Korisnik.Lozinka = student.Lozinka;
            studentDB.Korisnik.KorisnickoIme = student.KorisnickoIme;
            studentDB.Korisnik.Kontakt = student.Kontakt;
            studentDB.DatumUseljenja = student.DatumUseljenja;
            studentDB.Korisnik.UlogeId = 9;
            studentDB.KantonId = student.KantonId;
            ctx.SaveChanges();

            return RedirectToAction("Index");

        }

        private List<SelectListItem> UcitajKanton()
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