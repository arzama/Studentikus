using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Helper;



namespace NasSeminarski.Models
{
    public class Zaposlenik:IEntity
    {
          
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public string OpisPosla { get; set; }

        public virtual Korisnik Korisnik { get; set; }

    }
}