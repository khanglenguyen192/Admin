using Admin.Base.Services;
using Admin.Base.ViewModels;
using Admin.Models;
using Admin.Pages;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Admin.ViewModels
{
    public class UpdateProductPopupViewModel : BaseViewModel
    {
        private IPopupNavigation _popupNavigation;

        private const string Url = "http://localhost:5000/products/detail";

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _img;
        public string Img
        {
            get { return _img; }
            set
            {
                SetProperty(ref _img, value);
            }
        }

        private string _origin;
        public string Origin
        {
            get { return _origin; }
            set
            {
                SetProperty(ref _origin, value);
            }
        }

        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set
            {
                SetProperty(ref _brand, value);
            }
        }

        private long _price;
        public long Price
        {
            get { return _price; }
            set
            {
                SetProperty(ref _price, value);
            }
        }

        private string _style;
        public string Style
        {
            get { return _style; }
            set
            {
                SetProperty(ref _style, value);
            }
        }

        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
                SetProperty(ref _categoryID, value);
            }
        }

        private string _material;
        public string Material
        {
            get { return _material; }
            set
            {
                SetProperty(ref _material, value);
            }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                SetProperty(ref _size, value);
            }
        }

        private float _weight;
        public float Weight
        {
            get { return _weight; }
            set
            {
                SetProperty(ref _weight, value);
            }
        }

        private string _accessories;
        public string Accessories
        {
            get { return _accessories; }
            set
            {
                SetProperty(ref _accessories, value);
            }
        }

        private string _insurance;
        public string Insurance
        {
            get { return _insurance; }
            set
            {
                SetProperty(ref _insurance, value);
            }
        }


        public UpdateProductPopupViewModel(INavigationService navigationService, IPopupNavigation popupNavigation)
            : base(navigationService)
        {
            _popupNavigation = popupNavigation;
        }

        public void setProduct(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Img = product.Img;
            Origin = product.Origin;
            Brand = product.Brand;
            Price = product.Price;
            Style = product.Style;
            CategoryID = product.CategoryID;
            Material = product.Material;
            Size = product.Size;
            Weight = product.Weight;
            Accessories = product.Accessories;
            Insurance = product.Insurance;
        }

        public ICommand NavigateUpdateCommand => new Command(async () =>
        {
            if (Name.Equals(string.Empty))
            {
                return;
            }
            else if (Img.Equals(string.Empty))
            {
                return;
            }
            else if (Brand.Equals(string.Empty))
            {
                return;
            }
            else if (Insurance.Equals(string.Empty))
            {
                return;
            }

            Product product = new Product(Id, Name, Img, Origin, Brand, Price, Style, CategoryID, Material, Size, Weight, Accessories, Insurance);
            PutProduct(product, Url);

            ProductListPageLandscape.ReloadPage();
            await _popupNavigation.PopAsync();
        });

        public ICommand NavigateCloseCommand => new Command(async () =>
        {
            await _popupNavigation.PopAsync();
        });

        protected async void PutProduct(Product product, string url)
        {
            HttpClient client = new HttpClient();
            var serializeItem = JsonConvert.SerializeObject(product);
            StringContent body = new StringContent(serializeItem, Encoding.UTF8, "application/json");
            await client.PutAsync(url, body);
        }
    }
}
