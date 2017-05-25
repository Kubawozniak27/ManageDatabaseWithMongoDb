using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicShops.Models
{
    public class Product
    {


        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Display(Name ="Kategoria")]
        public Category Category { get; set; }

        [Display(Name = "Producent")]
        public string Producent { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Cena")]
        [BsonRepresentation(BsonType.Double)]
        public double Price { get; set; }

        [Range(0,10)]
        [Display(Name = "Jakość (0-10)")]
        [BsonRepresentation(BsonType.Double)]
        public double Quality { get; set; }

        public Description Description { get; set; }



        public Product()
        { }

        public  Product(PostProduct postProduct)
        {
           
            this.Category = postProduct.Category;
            this.Producent = postProduct.Producent;
            this.Model = postProduct.Model;
            this.Price = postProduct.Price;
            this.Quality = postProduct.Quality;
            this.Description = new Description();

            
        }
      
    }
}