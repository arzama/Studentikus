using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulGost.Models
{
    public class RezervacijaUrediViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [Required(ErrorMessage="Datum prijave je obavezno polje!")]
        [DataType(DataType.DateTime)]
        public DateTime? DatumPrijave { get; set; }
        [Required(ErrorMessage = "Datum odjave je obavezno polje!")]
        [DataType(DataType.DateTime)]
        [GreaterThan("DatumPrijave", ErrorMessage = "Datum odjave treba biti veći od datuma prijave!")]
        public DateTime? DatumOdjave { get; set; }
        //HashSet<int> integerSet1 = new HashSet<int>() { 1, 2, 3 };
        [Required]
        public string Poruka="Soba je vec rezervisana";
        public int BrojSobe { get; set; }
       
        public int? Status { get; set; }

    }
}