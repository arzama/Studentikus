using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{

    public class SkolskaGodina:IEntity
    { 
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int BrojSkolskeGodine{get;set;}
        public string AkademskaGodina{get;set;}

      

     
    } //end class
} //end namespace
