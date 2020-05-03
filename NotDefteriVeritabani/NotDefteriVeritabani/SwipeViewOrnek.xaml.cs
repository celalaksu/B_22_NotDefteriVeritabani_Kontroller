using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefteriVeritabani
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeViewOrnek : ContentPage
    {
        public SwipeViewOrnek()
        {
            InitializeComponent();
        }

        private void FavoriSwipeItem_Invoked(object sender, EventArgs e)
        {
            var eleman = (SwipeItem)sender;
            var label =(Label)eleman.FindByName("etiketLbl");
            label.Text = "Favorilere eklediniz.";
        }

        private void SilSwipeItem_Invoked(object sender, EventArgs e)
        {

        }
    }
}