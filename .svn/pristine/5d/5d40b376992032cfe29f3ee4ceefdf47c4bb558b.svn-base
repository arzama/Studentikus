using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NasSeminarski.Areas.ModulRecepcioner.Models;
using NasSeminarski.DAL;
using System.Data.Entity;
using NasSeminarski;
using NasSeminarski.Areas;
using NasSeminarski.Controllers;
using NasSeminarski.Models;
using MVC.Helper;

namespace NasSeminarski.Areas.ModulRecepcioner.Controllers
{
     [Autorizacija(KorisnickeUloge.Recepcioner)]
    public class StudentController : Controller
    {
       
        public ActionResult Index()
        {
            return View("Index");
        }
        MojContext ctx = new MojContext();

        // GET: Student
        public ActionResult Prikazi(string search)
        {
            StudentPrikaziViewModel Model = new StudentPrikaziViewModel();
            Model.studenti = ctx.Studenti.Where(x=> search== null || String.Concat(x.Korisnik.Ime," ", x.Korisnik.Prezime).Contains(search)).Include(x => x.Korisnik).ToList();
            return View("Prikazi", Model);
        }
        
        public ActionResult Obrisi(int studentID)
        {
            Student x = ctx.Studenti.Find(studentID);
            Korisnik a = ctx.Korisnici.Find(studentID);
          
            ctx.Studenti.Remove(x);
            ctx.Korisnici.Remove(a);
        
            ctx.SaveChanges();

            return RedirectToAction("Prikazi");
        }


        public ActionResult Dodaj()
        {
            StudentUrediViewModel Model = new StudentUrediViewModel();
            return View("Uredi", Model);
        }



        public ActionResult Snimi(StudentUrediViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", student);
            }
            Student studentDB;
            if (student.Id == 0)
            {
                studentDB = new Student();
                studentDB.Korisnik = new Korisnik();
                studentDB.Korisnik.UlogeId = 4;
                ctx.Studenti.Add(studentDB);

            }

            else
            {
                studentDB = ctx.Studenti.Where(x => x.Id == student.Id).Include(x => x.Korisnik).FirstOrDefault();

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
            studentDB.Korisnik.UlogeId = 4;
            ctx.SaveChanges();

            return RedirectToAction("Prikazi");

        }
        public ActionResult Uredi(int studentID)
        {
            StudentUrediViewModel Model = new StudentUrediViewModel();
            Student student = ctx.Studenti.Where(x => x.Id == studentID).Include(x => x.Korisnik).FirstOrDefault();

            Model.Id = student.Id;
            Model.DatumUseljenja = student.DatumUseljenja;
            Model.Ime = student.Korisnik.Ime;
            Model.Fakultet = student.Fakultet;
            Model.Prezime = student.Korisnik.Prezime;
            Model.DatumRodjenja = student.Korisnik.DatumRodjenja;
            Model.Adresa = student.Korisnik.Adresa;
            Model.Email = student.Korisnik.Email;
            Model.Lozinka = student.Korisnik.Lozinka;
            Model.KorisnickoIme = student.Korisnik.KorisnickoIme;
            Model.Kontakt = student.Korisnik.Kontakt;
            


            return View("Uredi", Model);
        }
  

    }
}


