using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Helper;

namespace NasSeminarski.Models
{
    public class Student:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DatumUseljenja { get; set; }
        public string Fakultet { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Kanton Kanton { get; set; }
        public int? KantonId { get; set; }
 
    }
}