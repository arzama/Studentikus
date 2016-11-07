using Foolproof;
using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava.Models
{
    public class ZaposlenikUrediViewModel
    {

       
            public int Id { get; set; }
            [Required(ErrorMessage = "Ime je obavezno polje")]
            public string Ime { get; set; }
            [Required(ErrorMessage = "Prezime je obavezno polje")]
            public string Prezime { get; set; }
            [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
            [DataType(DataType.Date)]
            public DateTime? DatumRodjenja { get; set; }
       
            [Required(ErrorMessage = "Adresa je obavezno polje")]
            public string Adresa { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [Required(ErrorMessage = "Kontakt je obavezno polje")]
            public string Kontakt { get; set; }
          
            [Required(ErrorMessage = "Korisnicko ime je obavezno polje")]
            public string KorisnickoIme { get; set; }

            [Required(ErrorMessage = "Lozinka je obavezno polje")]
            [StringLength(30, MinimumLength = 5, ErrorMessage = "Lozinka mora imati najmanje 5 a najviše 30 karaktera")]
            public string Lozinka { get; set; }

            [Required(ErrorMessage = "Datum zaposlenja je obavezno polje")]
            [DataType(DataType.Date)]
            [GreaterThan("DatumRodjenja", ErrorMessage = "Datum zaposlenja treba biti veći od datuma rođenja!")]
             public DateTime? DatumZaposlenja { get; set; }

            public string OpisPosla { get; set; }

            public List<SelectListItem> UlogaStavke { get; set; }
            public int UlogaId { get; set; }
        

     
      
    }
}