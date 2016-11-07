
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Models;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulRecepcioner.Models
{

    public class RezervacijaSobaPrikaziViewModel
    {

        public class rezervacijeInfo
        {
            public int Id { get; set; }
            public DateTime DatumPrijave { get; set; }
            public DateTime DatumOdjave { get; set; }
            public bool Realizovana { get; set; }
            public bool Otkazana { get; set; }
            public float Iznos { get; set; }
        }
        public List<rezervacijeInfo> rezervacije { get; set; }
        public List<SelectListItem> Sobestavke { get; set; }
        public int sobaId { get; set; }
        public List<SelectListItem> KorisnikStavka { get; set; }
        public int KorisnikId { get; set; }

    }
}
