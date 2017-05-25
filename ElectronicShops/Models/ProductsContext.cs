using ElectronicShops.Properties;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicShops.Models
{
    public class ProductsContext
    {
        public MongoDatabase database;

        public ProductsContext()
        {
            string connectionstring = "mongodb://mongovm9215.cloudapp.net";
            var client = new MongoClient(connectionstring);
            var server = client.GetServer();

            database = server.GetDatabase(Settings.Default.ProductsDatabase);
        }

        public MongoCollection<Product> Products
        {
            get
            {
                return database.GetCollection<Product>("product");
            }
        }
    }
}