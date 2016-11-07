using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulGost.Models
{
    public class RestoranUrediVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        //[Required(ErrorMessage = "Datum je obavezno polje!")]
        //[DataType(DataType.DateTime)]
        public DateTime? Datum { get; set; }

        public string Opis { get; set; }
    }
}