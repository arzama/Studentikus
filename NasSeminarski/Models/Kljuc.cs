using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Kljuc:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int BrojKljuca { get; set; }
        public int Kolicina { get; set; }
        public virtual Soba Soba { get; set; }
        public int SobaId { get; set; }

       
        
    } //end class
} //end namespace
