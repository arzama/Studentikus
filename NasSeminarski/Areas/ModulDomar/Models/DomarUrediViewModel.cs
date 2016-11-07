using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NasSeminarski.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace NasSeminarski.Areas.ModulDomar.Models
{
    public class DomarUrediViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public float Cijena { get; set; }
        

        public List<SelectListItem> SobeStavke { get; set; }
        public int sobaId { get; set; }
    }
}