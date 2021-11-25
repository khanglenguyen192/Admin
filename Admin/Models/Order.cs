using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models
{
    public class Order
    {
        [JsonProperty("orderID")]
        public int OrderId { get; set; }
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
        [JsonProperty("customerPhone")]
        public string CustomerPhone { get; set; }
        [JsonProperty("customerEmail")]
        public string CustomerEmail { get; set; }
        [JsonProperty("customerAddress")]
        public string CustomerAddress { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        public Order()
        {

        }

        public Order(int orderId, string customerName, string customerPhone, string customerEmail, string customerAddress, string detail, string paymentMethod, string status)
        {
            OrderId = orderId;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            CustomerAddress = customerAddress;
            Detail = detail;
            PaymentMethod = paymentMethod;
            Status = status;
        }
    }
}
