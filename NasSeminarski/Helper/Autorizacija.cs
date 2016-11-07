using System.Collections.Generic;
using System.Web.Mvc;
using NasSeminarski.Models;

namespace MVC.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        private readonly KorisnickeUloge[] _dozvoljeneUloge;

        public Autorizacija(params KorisnickeUloge[] dozvoljeneUloge)
        {
            _dozvoljeneUloge = dozvoljeneUloge;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login");
                return;
            }

            //provjera
            foreach (KorisnickeUloge x in _dozvoljeneUloge)
            {
                if (x == KorisnickeUloge.Recepcioner && k.Uloge != null)
                    return;
                if (x == KorisnickeUloge.Student && k.Uloge != null)
                    return;
                if (x == KorisnickeUloge.Gost && k.Uloge != null)
                    return;
                if (x == KorisnickeUloge.Domar && k.Uloge != null)
                    return;
                if (x == KorisnickeUloge.Sobarica && k.Uloge != null)
                    return;
                if (x == KorisnickeUloge.Upravnik && k.Uloge != null)
                    return;
                if (x == KorisnickeUloge.Racunovodja && k.Uloge != null)
                    return;
            }
            //ako funkcija nije prekinuta pomoću "return", onda korisnik nema pravo pistupa pa će se vršiti redirekcija na "/Home/Index"
            filterContext.HttpContext.Response.Redirect("/Meni");
        }
    }
    public enum KorisnickeUloge
    {
       
        Recepcioner,
        Student,
        Gost,
        Domar,
        Sobarica,
        Upravnik,
        Racunovodja
    }
}