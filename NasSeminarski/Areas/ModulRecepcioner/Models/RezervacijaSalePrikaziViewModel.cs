using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Models;
using NasSeminarski.Areas.ModulRecepcioner.Models;

namespace NasSeminarski.Areas.ModulRecepcioner.Models
{
    public class RezervacijaSalePrikaziViewModel
    {
        public List<Rezervacije> rezervacije { get; set; }

        public class Rezervacije
        {
            public int rezervacijaId { get; set; }
            public string Naziv { get; set; }
            public DateTime? Datum { get; set; }
            public string Opis { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string BrojTelefona { get; set; }
            public float Iznos { get; set; }

        }
    }
}