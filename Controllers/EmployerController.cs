using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelerikMvcApp1.Controllers
{
    public class EmployerController : Controller
    {
        readonly NorthwindEntities _context = new NorthwindEntities();

        // GET: Employer
        public ActionResult Index()
        {
            var employees = _context.Employees.Select(e => new
            {
                Id = e.EmployeeID,
                Name = e.FirstName + " " + e.LastName
            });
            return this.Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}