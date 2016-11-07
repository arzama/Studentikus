using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NasSeminarski.Areas.ModulDomar.Models
{
    public class DomarPrikaziViewModel
    {
        public class DomarInfo
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public float Cijena { get; set; }
            public int BrojSobe { get; set; }
            public int idSobe { get; set; }
        }
        public List<DomarInfo> inventari;
        public List<SelectListItem> SobeStavke { get; set; }
        public int sobaId { get; set; }

    }
}