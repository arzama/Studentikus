using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Helper;

namespace NasSeminarski.Models
{
    public class Uloge:IEntity
    {
        public int Id { get;set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
        public string Opis { get;set; }

    }
}