using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("img")]
        public string Img { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("price")]
        public long Price { get; set; }
        [JsonProperty("style")]
        public string Style { get; set; }
        [JsonProperty("category")]
        public int CategoryID { get; set; }
        public string Category { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("weight")]
        public float Weight { get; set; }
        [JsonProperty("accessories")]
        public string Accessories { get; set; }
        [JsonProperty("insurance")]
        public string Insurance { get; set; }

        public Product()
        {
            //Name = string.Empty;
            //Img = string.Empty;
            //Origin = string.Empty;
            //Brand = string.Empty;
            //Price = 0;
            //Style = string.Empty;
            //Category = 1;
            //Material = string.Empty;
            //Size = string.Empty;
            //Weight = 0;
            //Accessories = string.Empty;
            //Insurance = string.Empty;
            Category = "None";
        }

        public Product(int id, string name, string img, string origin, string brand, long price, string style, int categoryID, string material, string size, float weight, string accessories, string insurance)
        {
            Id = id;
            Name = name;
            Img = img;
            Origin = origin;
            Brand = brand;
            Price = price;
            Style = style;
            CategoryID = categoryID;
            Material = material;
            Size = size;
            Weight = weight;
            Accessories = accessories;
            Insurance = insurance;
        }
    
        public void setCategory()
        {
            switch (CategoryID)
            {
                case 1:
                    Category = "Đàn Piano";
                    break;
                case 2:
                    Category = "Đàn Organ";
                    break;
                case 3:
                    Category = "Đàn Guitar";
                    break;
                case 4:
                    Category = "Đàn Ukulele";
                    break;
                case 5:
                    Category = "Đàn Violin";
                    break;
                case 6:
                    Category = "Trống";
                    break;
                case 7:
                    Category = "Amplifier";
                    break;
                case 8:
                    Category = "Âm Thanh";
                    break;
                case 9:
                    Category = "Nhạc Cụ Hơi";
                    break;
                default:
                    Category = "None";
                    break;
            }
        }
    }
}
