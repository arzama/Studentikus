using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Areas.ModulRecepcioner.Models
{
    public class RezervacijaSobaUrediViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Datum prijave je obavezno polje!")]
        [DataType(DataType.DateTime)]
        public DateTime? DatumPrijave { get; set; }
        [Required(ErrorMessage = "Datum Odjave je obavezno polje!")]
        [DataType(DataType.DateTime)]
        [GreaterThan("DatumPrijave",ErrorMessage="Datum odjave treba biti veći od datuma prijave!")]
        public DateTime? DatumOdjave { get; set; }
        [Required(ErrorMessage = "Iznos rezervacije je obavezno polje!")]
        public float Iznos { get; set; }
        //HashSet<int> integerSet1 = new HashSet<int>() { 1, 2, 3 };
        [Required(ErrorMessage = "Broj sobe je obavezno odabrati!")]
        public int BrojSobe { get; set; }

        [Required(ErrorMessage = "Ime gosta je obavezno polje!")]
        public string Ime { get; set; }
         [Required(ErrorMessage = "Prezime gosta je obavezno polje!")]
        public string Prezime { get; set; }
        
        public DateTime? DatumRodjenja { get; set; }
        public string Adresa { get; set; }
         [Required(ErrorMessage = "E-mail adresa je obavezno polje!")]
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