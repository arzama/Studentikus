using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Models;
namespace NasSeminarski.Areas.ModulGost.Models
{
    public class RezervacijaPrikaziViewModel
    {
        public List<Rezervacije> rezervacije { get; set; }
        public class Rezervacije
        {
            public int rezervacijaId { get; set; }
            public DateTime? DatumPrijave { get; set; }
            public DateTime? DatumOdjave { get; set; }
            public int BrojSobe { get; set; }
            public int Dana { get; set; }
            public float? Iznos { get; set; }
        }
      
    }
}