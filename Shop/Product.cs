using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        public int Code { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public Product(int code, string name, int quantity, int price)
        {
            this.Code = code;
            this.ProductName = name;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
