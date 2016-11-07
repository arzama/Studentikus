using NasSeminarski.DAL;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NasSeminarski.Controllers
{
    public class RecepcionerController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: Recepcioner
        public ActionResult Prikazi()
        {
            List<Zaposlenik> recepcioneri = ctx.Zaposlenici.Include("Korisnik").ToList();

            ViewData["recepcioneri"] = recepcioneri;
            return View("Prikazi");
        }
    }
}