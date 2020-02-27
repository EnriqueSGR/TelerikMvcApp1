using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class modProducto
    {
        public int Id { get;  set; }
        public string NombreEnProducto { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public modSupplier Supplier { get; set; }
        public modCategoria Categoria { get; set; }

    }
}