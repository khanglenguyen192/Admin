using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models
{
    public class OrderItemDetail
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }

        public OrderItemDetail()
        {

        }

        public OrderItemDetail(string name, string img, long price, int quantity)
        {
            Name = name;
            Img = img;
            Price = price;
            Quantity = quantity;
        }
    }
}
