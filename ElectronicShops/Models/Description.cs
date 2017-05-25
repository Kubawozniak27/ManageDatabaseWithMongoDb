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
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string Opis { get; set; }

        
        

        public Description()
        {
          
        }


    }
}