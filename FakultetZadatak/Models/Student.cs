using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FakultetZadatak.Models
{
    public class Student
    {
        [Display(Name = "Broj indeksa")]
        public int bi { get; set; }
        [Display(Name = "Godina studija")]
        public int godina_studija { get; set; }
        [Display(Name = "GrupaID")]
        public int grupa_id { get; set; }
        [Display(Name = "Ime i prezime")]
        public string Ime_i_prezime { get; set; }
        [Display(Name = "Datum rodjenja")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime datum_rodjenja { get; set; }
        public string Grad { get; set; }


        
    }
}