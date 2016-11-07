using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski.Models
{
    public class Troskovi
    {
        public int id { get; set; }
        public string svrhaTroska { get; set; }
        public double iznosTroska { get; set; }
        public DateTime rokIsplate { get; set; }
        public bool uplaceno { get; set; }
    }
}