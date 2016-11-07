using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulRecepcioner.Models
{
    public class RezervacijaSaleUrediVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv dešavanja je obavezno polje!")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Datum dešavanja je obavezno polje!")]
        [DataType(DataType.DateTime)]
        public DateTime? Datum { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage = "Ime posjetioca je obavezno polje!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime posjetioca je obavezno polje!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Broj telefona posjetioca je obavezno polje!")]
        public string BrojTelefona { get; set; }

        [Required(ErrorMessage = "Cijena dešavanja je obavezno polje!")]
        public float Iznos { get; set; }
    }
}