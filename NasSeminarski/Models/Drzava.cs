using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Helper;

namespace NasSeminarski.Models
{
    public class Drzava:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
    }
}