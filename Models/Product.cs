﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int Id { get;  set; }
        [DataType("String")]
        [Required]
        public string Name { get; set; }
        [DataType("Currency")]
        [Required]
        public decimal? UnitPrice { get; set; }
        [DataType("Integer")]
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        [UIHint("SupplierEditor")]
        public Supplier Supplier { get; set; }
        [UIHint("CategoryEditor")]
        public Category Category { get; set; }

    }
}