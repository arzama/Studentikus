using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Racun:IEntity
    { 
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int ?Kolicina { get; set; }
        public float ?Cijena { get; set; }
        public float Iznos { get; set; }
        public bool? uplaceno { get; set; }
        public int? MjesecObracunId { get; set; }
        public MjesecObracun MjesecObracun { get; set; }

        public int? UgovorOStanovanjuId { get; set; }
        public virtual UgovorOStanovanju UgovorOStanovanju { get; set; }

        public int? ZaposlenikId { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public int? KorisnikId { get; set; }

    } //end class
} //end namespace
