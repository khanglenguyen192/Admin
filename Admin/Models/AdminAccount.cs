using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models
{
    public class AdminAccount
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        public AdminAccount()
        {
            UserName = string.Empty;
            Password = string.Empty;
            FullName = string.Empty;
        }

        public AdminAccount(string userName, string password, string fullName)
        {
            UserName = userName;
            Password = password;
            FullName = fullName;
        }
    }
}
