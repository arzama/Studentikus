using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Domar 
    { 
        //Fields
     
        public int Id { get; set; }
        public DateTime DatumZaposlenja{get;set;}
        public string OpisPosla{get;set;}
        public Korisnik Korisnik{get; set;}

        public int KorisnikId { get; set; }
       
        //Properties
       
        //Methods

    } //end class
} //end namespace
