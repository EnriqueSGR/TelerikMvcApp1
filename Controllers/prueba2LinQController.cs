//************ COMIENZA

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikMvcApp1.Models;


namespace TelerikMvcApp1.Controllers
{



    public class prueba2LinQController : Controller
    {

        readonly NorthwindEntities _context = new NorthwindEntities();

        public ActionResult Index()
        {

            return View();
        }



        //[AcceptVerbs(HttpVerbs.Get)]


        public JsonResult Get([DataSourceRequest]DataSourceRequest request)
        {

            //***************** COMIENZA


            var Details = _context.Employees

               .Select(p => new Models.modEmployee
               {
                   EmployeeID = p.EmployeeID,
                   LastName = p.LastName,
                   FirstName = p.FirstName,
                   Title = p.Title,
                   City = p.City,



               });
            return Json(Details.ToDataSourceResult(request));
        }

        public ActionResult HierarchyBinding_Orders(int employeeID, [DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders()
                .Where(order => order.EmployeeID == employeeID)
                .ToDataSourceResult(request));
        }

        private static IEnumerable<modOrders> GetOrders()
        {
            var northwind = new NorthwindEntities();






            return northwind.Orders.Select(order => new modOrders
            {
                EmployeeID = order.EmployeeID,
                OrderId = order.OrderID,
                OrderDate = order.OrderDate,
                ShipAddress = order.ShipAddress,
                Shipcity = order.ShipCity

            });
        }

    }
}
//************** FINALIZA
