using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulUprava.Models
{
    public class ZaposlenikPrikaziViewModel
    {
        public class ZaposlenikInfo
        {
            public int Id { get; set; }

            public string Ime { get; set; }
            public string Prezime { get; set; }
       
            public string Email { get; set; }
            public string Kontakt { get; set; }
          
            public DateTime? DatumZaposlenja { get; set; }


            public string UlogaNaziv;
        }
        public List<ZaposlenikInfo> zaposlenici;

        public List<SelectListItem> UlogeStavke { get; set; }
        public int UlogaId { get; set; }
    }
}