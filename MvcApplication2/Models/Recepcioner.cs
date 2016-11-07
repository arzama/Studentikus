
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models  
{

    public class Recepcioner 
    { 
        //Fields
        public int Id { get; set; }
        public DateTime DatumZaposlenja{get; set;}
        public string OpisPosla {get; set;}
        public Korisnik Korisnik {get; set;}
       
        public int KorisnikId { get; set; }
       
        

        
        //Methods

    } //end class
} //end namespace
