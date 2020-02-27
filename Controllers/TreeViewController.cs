using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelerikMvcApp1.Controllers
{
    public class TreeViewController : Controller
    {
        readonly NorthwindEntities _context = new NorthwindEntities();

        // GET: Employer
        public ActionResult Index(int? id)
        {
            var employees = _context.Employees
                .Where(e => id.HasValue ? e.ReportsTo == id : e.ReportsTo == null)
                .Select(e => new
                {
                    id = e.EmployeeID,
                    Name = e.FirstName + " " + e.LastName,
                    hasChildren = e.Employees1.Any()
                });
               
           
            return this.Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}