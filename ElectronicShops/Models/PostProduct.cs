using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicShops.Models
{
    public class PostProduct
    { 
        [Display(Name ="Kategoria")]
        public Category Category { get; set; }
        [Display(Name ="Producent")]
        public string Producent { get; set; }
        [Display(Name ="Model")]
        public string Model { get; set; }
        [Display(Name ="Cena")]
        public double Price { get; set; }
        [Display(Name ="Jakość (0-10)")]
        [Range(0,10)]
        public double Quality { get; set; }

        public Description Description { get; set; }
    }
    
}