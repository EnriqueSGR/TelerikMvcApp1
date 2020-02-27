//*************** COMIENZA

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class modOrders
    {
        //Orders
        public int? EmployeeID { get; set; }
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string Shipcity { get; set; }
    }
}

//**************** FINALIZA