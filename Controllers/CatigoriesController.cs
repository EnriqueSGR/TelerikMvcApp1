using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelerikMvcApp1.Controllers
{
    public class CategoriesController : Controller
    {
        readonly NorthwindEntities _entities = new NorthwindEntities();

        // GET: Categories
        public JsonResult Index()
        {
            var categories = _entities.Categories.Select(s => new Models.Category
            {
                Id = s.CategoryID,
                Name = s.CategoryName
            });

            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}