using ElectronicShops.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ElectronicShops.Controllers
{
    public class ProductsController : Controller
    {
        public readonly ProductsContext context = new ProductsContext();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductsByFilter(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.TypeSort = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.ModelSort = sortOrder == "modelsort" ? "modelsort_desc" : "modelsort";
            ViewBag.ProducentSort = sortOrder == "producentsort" ? "producentsort_desc" : "producentsort";
            ViewBag.PriceSort = sortOrder == "pricesort" ? "pricesort_desc" : "pricesort";
            ViewBag.QualitySort = sortOrder == "qualitysort" ? "qualitysort_desc" : "qualitysort";

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;



  
            var model = context.Products.FindAll().ToList();

            if (!String.IsNullOrEmpty(search))
            {
                model = model.Where(r =>
                (/*(CultureInfo.CurrentCulture.CompareInfo.IndexOf(r.Type, search, CompareOptions.IgnoreCase) >= 0) ||*/
                 (CultureInfo.CurrentCulture.CompareInfo.IndexOf(r.Model, search, CompareOptions.IgnoreCase) >= 0) ||
                  (CultureInfo.CurrentCulture.CompareInfo.IndexOf(r.Producent, search, CompareOptions.IgnoreCase) >= 0))).ToList();
            }

            switch (sortOrder)
            {
                //case "type_desc":
                //    model = model.OrderByDescending(m => m.Type).ToList();
                //    break;

                case "modelsort":
                    model = model.OrderBy(m => m.Model).ToList();
                    break;
                case "modelsort_desc":
                    model = model.OrderByDescending(m => m.Model).ToList();
                    break;

                case "producentsort":
                    model = model.OrderBy(m => m.Producent).ToList();
                    break;
                case "producentsort_desc":
                    model = model.OrderByDescending(m => m.Producent).ToList();
                    break;

                case "pricesort":
                    model = model.OrderBy(m => m.Price).ToList();
                    break;
                case "pricesort_desc":
                    model = model.OrderByDescending(m => m.Price).ToList();
                    break;

                case "qualitysort":
                    model = model.OrderBy(m => m.Quality).ToList();
                    break;
                case "qualitysort_desc":
                    model = model.OrderByDescending(m => m.Quality).ToList();
                    break;

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            return PartialView(model.ToPagedList(pageNumber, pageSize));         
        }
        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(PostProduct product)
        {
            var item = new Product(product);
            item.Description = new Description();
            context.Products.Insert(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {


            var product = GetProduct(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            IMongoQuery query = Query.EQ("_id", new ObjectId(product.Id));

            IMongoUpdate updateQuery = Update
                .Set("Category", product.Category)
                .Set("Producent", product.Producent)
                .Set("Model", product.Model)
                .Set("Price", (double)product.Price)
                .Set("Quality", product.Quality);

            context.Products.Update(query, updateQuery);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id)
        {
            context.Products.Remove(Query.EQ("_id", new ObjectId(id)));
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Description(string id)
        {

            var product = GetProduct(id);


            if (product.Description == null)
            {
                Description descri = new Description();
                product.Description = descri;
                context.Products.Save(product);
            }

            return View(product);           
        }


        [HttpGet]
        public ActionResult PostDescription(string id)
        {
            var product = GetProduct(id);
            var Description = product.Description;
            return View(Description);
        }


        [HttpPost]
        public ActionResult PostDescription(string id, Description description)
        {
            var item = GetProduct(id);
            item.Description = description;
            context.Products.Save(item);
            return RedirectToAction("Index");
        }




        private Product GetProduct(string id)
        {
            var product = context.Products.FindOneById(new ObjectId(id));
            return product;
        }
    }
}