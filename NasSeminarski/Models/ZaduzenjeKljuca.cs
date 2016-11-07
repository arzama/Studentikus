using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
 {
    public class ZaduzenjeKljuca:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DatumPreuzimanja{get;set;}
        public DateTime? DatumVracanja{get;set;}

        public bool Aktivan { get; set; }
        public int KorisnikId { get; set; }
        public int KljucId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Kljuc Kljuc { get; set; }

       
    } //end class
} //end namespace
