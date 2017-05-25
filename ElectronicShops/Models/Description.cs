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
        public Description(string Opis)
        {
            this.Opis = Opis;
        }

        public Description()
        {}

        public Description(Description description)
        {
            this.Opis = description.Opis;
        }

    }
}