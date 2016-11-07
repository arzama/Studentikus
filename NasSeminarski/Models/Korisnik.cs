using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Korisnik:IEntity
    { 
        //Fields
       
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Ime{get;set;}
        public string Prezime{get;set;}
        public DateTime? DatumRodjenja{get;set;}
        public string Adresa{get;set;}
        public string Email { get; set; }
        public string Kontakt { get; set; }

        [MaxLength(450)]
        [Index(IsUnique = true)]
        public string KorisnickoIme{get;set;}
        public string Lozinka{get;set;}

        public virtual Zaposlenik Zaposlenik{get;set;}
        public virtual Student Student { get; set; }

        public virtual Uloge Uloge { get; set; }
        public int? UlogeId { get; set; }
 

    } //end class
} //end namespace
