using Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Admin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPageLandscape : ContentView
    {
        public ProductListPageLandscape()
        {
            InitializeComponent();
        }

        //public void ItemRemoveClicked(object sender, EventArgs e)
        //{
        //    var item = (Button)sender;
        //    debugText.Text = item.CommandParameter.ToString();
        //    MessagingCenter.Send<ContentView, int>(this, "ProductListRemovedItem", (int)item.CommandParameter);
        //}
    }
}