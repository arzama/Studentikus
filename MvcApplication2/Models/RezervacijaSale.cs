using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models{

    public class RezervacijaSale 
    {
        public int Id { get; set; }

        public int DesavanjaId { get; set; }
        public Desavanja Desavanja { get; set; }

    } //end class
} //end namespace
