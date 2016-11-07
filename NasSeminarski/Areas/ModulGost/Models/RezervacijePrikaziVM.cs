using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulGost.Models
{
    public class RezervacijePrikaziVM
    {
        DateTime datum = DateTime.Now;
        public List<Rezervacije> rezervacije { get; set; }
        //[Required(ErrorMessage = "Datum prijave je obavezno polje!")]
        [DataType(DataType.Date)]
        //[GreaterThan("datum", ErrorMessage = "Datum prijave treba biti veći od današnjeg datuma !")]
        public DateTime? DatumPrijave { get; set; }
        //[Required(ErrorMessage = "Datum odjave je obavezno polje!")]
        [DataType(DataType.DateTime)]
        //[GreaterThan("DatumPrijave", ErrorMessage = "Datum odjave treba biti veći od datuma prijave!")]
        public DateTime? DatumOdjave { get; set; }
        public int? BrojOsoba { get; set; }
        public List<int> SobaId { get; set; }
        public class Rezervacije
        {
            public int Id { get; set; }
            public int BrojSobe { get; set; }
        }
    }
}