using NasSeminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{

    public class EvidencijaObroka:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? Vrijeme { get; set; }
        public virtual Student Student { get; set; }
        public int ?studentId { get; set; }
        public bool ?Uplaceno { get; set; }
        public int ?BrojObroka { get; set; }
        public int? UgovorOStanovanjuId { get; set; }
        public int? MjesecObracunId { get; set; }
        public UgovorOStanovanju UgovorOStanovanju { get; set; }
        public MjesecObracun MjesecObracun { get; set; }



    } //end class
} //end namespace
