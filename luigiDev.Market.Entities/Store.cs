using System;
using System.Collections.Generic;
using System.Text;

namespace luigiDev.Market.Entities
{
    public class Store
    {
        public Guid StoreId = Guid.NewGuid();
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
