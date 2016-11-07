using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Inventar:IEntity
    {
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public float Cijena { get; set; }
        public bool? Upotrebljivo { get; set; }
    
        public int ZaposlenikId { get; set; }
        public int SobaId { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public virtual Soba Soba { get; set; }

    } //end class
} //end namespace
