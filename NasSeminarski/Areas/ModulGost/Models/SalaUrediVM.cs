using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulGost.Models
{
    public class SalaUrediVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Datum je obavezno polje!")]
        //[GreaterThan("datum", ErrorMessage = "Datum odjave treba biti veći od datuma prijave!")]
        [DataType(DataType.DateTime)]
        public DateTime? Datum { get; set; }

        public string Opis { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
    
    }
}