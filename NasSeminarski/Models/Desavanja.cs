using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{

    public class Desavanja:IEntity
    {
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
        public DateTime? Datum { get; set; }
        public string Opis { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public bool? Otkazano { get; set; }

        public int? ZaposlenikId { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }

        public int? KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int? RacunId { get; set; }
        public Racun Racun { get; set; }
        //Methods

    } //end class
    //end namespace
}