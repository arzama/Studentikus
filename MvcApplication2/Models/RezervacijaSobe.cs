using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models{ 

    public class RezervacijaSobe 
    { 
        //Fields
        public int Id { get; set; }
        public string Naziv{get; set;}
        public DateTime DatumPrijave{get; set;}
        public DateTime DatumOdjave{get; set;}

       
        public int RecepcionerId { get; set; }
        public Recepcioner Recepcioner { get; set; }

        public int SobaId { get; set; }
        public Soba Soba { get; set; }


        public int GostId { get; set; }
        public Gost Gost { get; set; }
      
      
        public int RacunId { get; set; }
        public Racun Racun { get; set; }
      



    } //end class
} //end namespace
