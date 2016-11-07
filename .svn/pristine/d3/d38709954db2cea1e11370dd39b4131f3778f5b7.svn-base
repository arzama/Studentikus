using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class OdrzavanjeSobe:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Datum { get; set; }
        public string Komentar { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public virtual Soba Soba { get; set; }

        public int ZaposlenikId { get; set; }
        public int SobaId { get; set; }
    }
}