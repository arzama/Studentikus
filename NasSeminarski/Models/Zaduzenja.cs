using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Zaduzenja
    {
        public int Id { get; set; }
        public double IznosZaduzenja { get; set; }
        public bool Placeno { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

    }
}