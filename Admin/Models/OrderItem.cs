using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models
{
    public class OrderItem
    {
        [JsonProperty("orderID")]
        public int OrderId { get; set; }
        [JsonProperty("productID")]
        public int ProductId { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
