using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicShops.Models
{
    public class Description
    {
        public String Opis { get; set; }

        public Dictionary<string,string> Parameters { get; set; }

        public Description()
        {
        }

        public Description(Description description)
        {
            this.Opis = description.Opis;
            Parameters = new Dictionary<string, string>();
            this.Parameters.Add("Procesor", "");
            this.Parameters.Add("Przekątna ekranu", "");
            this.Parameters.Add("Aparat", "");
            this.Parameters.Add("Pamięć RAM", "");
            this.Parameters.Add("Grafika", "");
            this.Parameters.Add("Bateria", "");
            this.Parameters.Add("System", "");
            this.Parameters.Add("Waga", "");
        }

        public Description(Category category)
        {
            Parameters = new Dictionary<string, string>();
            switch (category)
            {
                case Category.Laptop:
                    this.Parameters.Add("Procesor", "");
                    this.Parameters.Add("Przekątna ekranu", "");
                    this.Parameters.Add("Pamięć RAM", "");
                    this.Parameters.Add("Karta graficzna", "");
                    this.Parameters.Add("Bateria", "");
                    this.Parameters.Add("System", "");
                    this.Parameters.Add("Waga", "");
                    break;
                case Category.Telefon:
                    this.Parameters.Add("Procesor", "");
                    this.Parameters.Add("Przekątna ekranu", "");
                    this.Parameters.Add("Aparat", "");
                    this.Parameters.Add("Pamięć RAM", "");
                    this.Parameters.Add("Pamięć wbudowana", "");
                    this.Parameters.Add("Karty pamieci", "");
                    this.Parameters.Add("Bateria", "");
                    this.Parameters.Add("System", "");
                    this.Parameters.Add("Waga", "");
                    this.Parameters.Add("Wymiary", "");
                    break;
                case Category.Tablet:
                    this.Parameters.Add("Procesor", "");
                    this.Parameters.Add("Przekątna ekranu", "");
                    this.Parameters.Add("Aparat", "");
                    this.Parameters.Add("Pamięć RAM", "");
                    this.Parameters.Add("Pamięć wbudowana", "");
                    this.Parameters.Add("Karty pamieci", "");
                    this.Parameters.Add("Bateria", "");
                    this.Parameters.Add("System", "");
                    this.Parameters.Add("Waga", "");
                    this.Parameters.Add("Wymiary", "");
                    break;
                
            }
        }

    }
}