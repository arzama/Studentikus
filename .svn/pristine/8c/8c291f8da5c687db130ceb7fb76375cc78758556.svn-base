using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulGost.Models
{
    
    public class RegistracijaDodajViewModel
    {
        public List<Korisnik> korisnici;
        public int Id { get; set; }
        [Required(ErrorMessage="Ime je obavezno polje!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje!")]
        public string Prezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        [Required(ErrorMessage = "E-mail je obavezno polje!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kontakt telefon je obavezno polje!")]
        public string Kontakt { get; set; }
        [Required(ErrorMessage = "Korisničko ime je obavezno polje!")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezno polje!")]
        public string Lozinka { get; set; }
    }
}