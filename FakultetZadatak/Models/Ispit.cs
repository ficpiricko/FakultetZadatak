using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakultetZadatak.Models
{
    public class Ispit
    {
        public int id { get; set; }
        [Display(Name = "Broj indeksa")]
        public int bi { get; set; }
        [Display(Name = "PredmetID")]
        public int predmet_id { get; set; }
        [Display(Name = "Ocena")]
        public int ocena { get; set; }

      
    }
}