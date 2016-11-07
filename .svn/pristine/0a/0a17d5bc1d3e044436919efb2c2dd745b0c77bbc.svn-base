using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.DAL;
using NasSeminarski.Models;

namespace NasSeminarski.Areas.ModulSobarica2.Helper
{
    public class ProvjeraRezervacije
    {
        public static RezervacijaSobe getRezervacija(Soba soba, DateTime d1)
        {
            MojContext db = new MojContext();
                //doradi ovaj upit tako da uzmeš u obzir  datum za koji povjeravaš rezervaciju
               return db.RezervacijeSoba.Where(r=>r.SobaId==soba.Id && r.DatumOdjave>=d1 && r.DatumPrijave<=d1).FirstOrDefault();
            }
        }
    }
