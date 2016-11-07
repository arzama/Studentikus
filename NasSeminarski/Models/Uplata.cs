using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Uplata
    {
        public int Id { get; set; }
        public DateTime DatumUplate { get; set; }
        public double IznosUplate { get; set; }
        public string svrhaUplate { get; set; }

        public virtual Student Student { get; set; }
        public int studentId { get; set; }
    }
}