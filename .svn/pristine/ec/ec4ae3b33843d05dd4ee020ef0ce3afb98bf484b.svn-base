
using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models{ 

    public class RezervacijaSobe:IEntity
    { 
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
       
        public DateTime? DatumPrijave{get; set;}
       
        public DateTime? DatumOdjave{get; set;}

        public bool? Otkazana { get; set; }
        public bool? Realizovana { get; set; }

        public int ?SobaId { get; set; }
        public Soba Soba { get; set; }

        public int ?KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int? RacunId { get; set; }
        public virtual Racun Racun { get; set; }


    } //end class
} //end namespace
