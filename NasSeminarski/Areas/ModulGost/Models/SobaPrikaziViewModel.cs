using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Models;
namespace NasSeminarski.Areas.ModulGost.Models
{
    public class SobaPrikaziViewModel
    {
        public List<Soba> sobe;
        public int brojSobe { get; set; }
        public DateTime datumPrijave { get; set; }
        public DateTime datumOdjave { get; set; }
    }
}