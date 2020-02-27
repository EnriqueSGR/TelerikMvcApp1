using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMvcApp1;

namespace TelerikMvcApp1.Controllers
{

    

    public class ProductosController : Controller
    {

        readonly NorthwindEntities _context = new NorthwindEntities();
        // GET: Productos
        //[AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            ViewData["defaultSuppler"] = _context.Suppliers.Select(s => new Models.Supplier { Id = s.SupplierID, Name = s.CompanyName }).First();
            ViewData["defaultCategory"] = _context.Categories.Select(c => new Models.Category { Id = c.CategoryID, Name = c.CategoryName }).First();
            return View();
        }


        //[AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var productos = _context.Products
                .Select(p => new Models.Product
                {
                    Id = p.ProductID,
                    Name = p.ProductName,
                    UnitsInStock = (int)p.UnitsInStock,
                    UnitPrice = p.UnitPrice,
                    Discontinued = p.Discontinued,
                    Supplier = new Models.Supplier
                    {
                        Id = p.Supplier.SupplierID,
                        Name = p.Supplier.CompanyName
                    },
                    Category = new Models.Category
                    {
                        Id = p.Category.CategoryID,
                        Name = p.Category.CategoryName
                    }
                });

            return this.Json(productos.ToDataSourceResult(request));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Update([DataSourceRequest]DataSourceRequest request, Models.Product producto)
        {
            if (producto != null && ModelState.IsValid)
            {
                var productToUpdate = _context.Products.Where(p => p.ProductID == producto.Id).FirstOrDefault();

                productToUpdate.ProductName = producto.Name;
                productToUpdate.SupplierID = producto.Supplier.Id;
                productToUpdate.CategoryID = producto.Category.Id;
                productToUpdate.UnitsInStock = (short)producto.UnitsInStock;
                productToUpdate.UnitPrice = producto.UnitPrice;
                productToUpdate.Discontinued = producto.Discontinued;
              
            }

            _context.SaveChanges();
            return this.Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }



        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        //public ActionResult Index()
        //{
        //    var productos = _context.Products
        //        .Select(p => new Models.modProducto
        //        {
        //            Id = p.ProductID,
        //            NombreEnProducto = p.ProductName,
        //            UnitsInStock = (int)p.UnitsInStock,
        //            UnitPrice = p.UnitPrice,
        //            Discontinued = p.Discontinued,
        //            Supplier = new Models.modSupplier
        //            {
        //                Id = p.Supplier.SupplierID,
        //                NombreEnSupplier = p.Supplier.CompanyName
        //            },
        //            Categoria = new Models.modCategoria
        //            {
        //                Id = p.Category.CategoryID,
        //                NombreEnCategoria = p.Category.CategoryName
        //            }
        //        });
        //    return View(productos);
        //}


    }
}