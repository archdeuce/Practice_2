﻿using System;
using System.Collections.Generic;

namespace DbFirst.Models
{
    public partial class OldProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }
    }
}
