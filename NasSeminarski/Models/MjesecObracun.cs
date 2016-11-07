using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class MjesecObracun:IEntity
    { 
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Godina { get; set; }
        public int Mjesec { get; set; }

      
       
    } //end class
} //end namespace
