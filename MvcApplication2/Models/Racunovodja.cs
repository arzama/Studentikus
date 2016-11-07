using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Racunovodja 
    {
        public int Id { get; set; }
        public DateTime DatumZaposlenja{get;set;}
        public string OpisPosla{get;set;}
        public Korisnik Korisnik{get;set;}
       
        public int KorisnikId { get; set; }
       
    } //end class
} //end namespace
