using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models
{
    public class MaxProductId
    {
        [JsonProperty("maxId")]
        public string MaxId { get; set; }
    }
}
