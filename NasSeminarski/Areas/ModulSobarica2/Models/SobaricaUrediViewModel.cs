using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulSobarica2.Models
{
    public class SobaricaUrediViewModel
    {
      
        public int Id { get; set; }
        [Required(ErrorMessage="Datum je obavezno polje!")]
        [DataType(DataType.Date)]
        public DateTime? Datum { get; set; }

        public int ZaposlenikId { get; set; }

        public string Komentar { get; set; }

        public List<SelectListItem> SobeStavke { get; set; }
        public int SobaId { get; set; }
    }
}