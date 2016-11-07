using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Korisnik 
    { 
        //Fields
       
        public int Id { get; set; }
        public string Ime{get;set;}
        public string Prezime{get;set;}
        public DateTime DatumRodjenja{get;set;}
        public string Adresa{get;set;}
        public string KorisnickoIme{get;set;}
        public string Lozinka{get;set;}
        public Upravnik Upravnik{get;set;}
        public Racunovodja Racunovodja{get;set;}
        public Domar Domar{get;set;}
        public Sobarica Sobarica{get;set;}
        public Student Student{get;set;}
        public Gost Gost{get;set;}
        public Recepcioner Recepcioner{get;set;}

        public int UpravnikId { get; set;}
        public int RacunovodjaId { get; set; }
        public int DomarId { get; set; }
        public int SobaricaId { get; set; }
        public int StudentId { get; set; }
        public int GostId { get; set; }
        public int RecepcionerId { get; set; }

      
       

    } //end class
} //end namespace
