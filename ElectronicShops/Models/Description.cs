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
        public Description(string Opis)
        {
            this.Opis = Opis;
            
        }

        public Description()
        {
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

    }
}