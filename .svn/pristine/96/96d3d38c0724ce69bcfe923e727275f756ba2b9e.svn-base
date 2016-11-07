using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.DAL;
namespace NasSeminarski.Models
{
    public class Soba:IEntity
    { 
        //Fields
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int BrojSobe { get; set; }
        public int Sprat { get; set; }
        public int BrojOsoba { get; set; }
        public int? StatusSobeId { get; set; }
        public string Detalji { get; set; }
        public float Cijena { get; set; }
        public virtual StatusSobe StatusSobe { get; set; }

    } //end class
} //end namespace

