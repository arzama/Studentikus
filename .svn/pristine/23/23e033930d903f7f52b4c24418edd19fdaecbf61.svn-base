using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Helper;

namespace NasSeminarski.Models
{
    public class Recenzije:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Komentar { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public DateTime Datum { get; set; }
    }
}