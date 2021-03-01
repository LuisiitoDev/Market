using System;
using System.Collections.Generic;
using System.Text;

namespace luigiDev.Market.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid StoreId { get; set; }
    }
}
