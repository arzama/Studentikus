using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class UgovorOStanovanju:IEntity
    { 
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Datum{get;set;}
        public int BrojKartice{get;set;}
      
        public int? SkolskaGodinaId { get; set; }
        public virtual SkolskaGodina SkolskaGodina { get; set; }

        public int? SobaId { get; set; }
        public virtual Soba Soba { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        
       


       
    } //end class
} //end namespace
