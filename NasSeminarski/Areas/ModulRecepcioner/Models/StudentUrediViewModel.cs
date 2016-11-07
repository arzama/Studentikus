using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace NasSeminarski.Areas.ModulRecepcioner.Models
{
    public class StudentUrediViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Datum useljenja je obavezno polje!")]
         [DataType(DataType.Date)]
        public DateTime? DatumUseljenja { get; set; }
        [Required(ErrorMessage = "Naziv fakulteta je obavezno polje!")]
        public string Fakultet { get; set; }
        [Required(ErrorMessage = "Ime studenta je obavezno polje!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime studenta je obavezno polje!")]
        public string Prezime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }

        public string Adresa { get; set; }
        [Required(ErrorMessage = "E-mail adresa je obavezno polje!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje!")]
        public string Lozinka { get; set; }

        [Required(ErrorMessage = "Korisnicko ime je obavezno polje!")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Kontakt telefon je obavezno polje!")]
        public string Kontakt { get; set; }

    }
}