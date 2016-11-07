using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Models;
using System.ComponentModel.DataAnnotations;
using Foolproof;
namespace NasSeminarski.Areas.ModulGost.Models
{
    public class RezervacijeUrediVM
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Datum prijave je obavezno polje!")]
        // [DataType(DataType.Date)]
        ////[GreaterThan(DateTime.Now.ToString(), ErrorMessage="Datum prijave treba biti veći od današnjeg datuma !")]
        public DateTime? DatumPrijave { get; set; }
        //[Required(ErrorMessage = "Datum odjave je obavezno polje!")]
        //[DataType(DataType.DateTime)]
        //[GreaterThan("DatumPrijave", ErrorMessage = "Datum odjave treba biti veći od datuma prijave!")]
        public DateTime? DatumOdjave { get; set; }
        public int? KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int BrojSobe { get; set; }
    }
}