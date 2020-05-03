using NotDefteriVeritabani.VeriModelleri;
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
    public partial class IkiNotGirisPage : ContentPage
    {
        Notlar not;
        public IkiNotGirisPage()
        {
            InitializeComponent();
            not = new Notlar();
            notGirisStackLayout.BindingContext = not;
        }

        protected override void OnAppearing()
        {
            ListeGuncelle();
        }

        private async void kaydetButton_Clicked(object sender, EventArgs e)
        {
            var not = (Notlar)notGirisStackLayout.BindingContext;
            not.NotTarih = DateTime.UtcNow;
            int sonuc;

            if (not.ID == 0)
                sonuc = await App.NotlarVeritabani.YeniNotEkle(not);
            else
                sonuc = await App.NotlarVeritabani.NotGuncelle(not);

            if (sonuc > 0)
                await DisplayAlert("İşlem Başarılı", "İşleminiz başarıyla gerçekleştirildi.", "Tamam");
            else
                await DisplayAlert("İşlem Başarısız", "İşleminiz yapılırken hata oluştu.", "Tamam");

            not = new Notlar();
            notGirisStackLayout.BindingContext = not;
            notGirisi.Text = String.Empty;
            ListeGuncelle();
        }

        private async void silButton_Clicked(object sender, EventArgs e)
        {
            var not = (Notlar)notGirisStackLayout.BindingContext;
            int sonuc = await App.NotlarVeritabani.NotSil(not);
            if (sonuc > 0)
            {
                await DisplayAlert("Başarılı", "Notunuz başarıyla silindi.", "Tamam");
            }
            else
            {
                await DisplayAlert("Başarısız", "Notunuz silinirken hata oluştu.", "Tamam");
            }

            not = new Notlar();
            notGirisStackLayout.BindingContext = not;
            notGirisi.Text = String.Empty;
            ListeGuncelle();
        }

        private void notlarListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var not = (Notlar)e.SelectedItem;
            notGirisStackLayout.BindingContext = not;
        }

        async void ListeGuncelle()
        {
            List<Notlar> notlar = await App.NotlarVeritabani.NotlariListele();
            notlarListView.ItemsSource = notlar.OrderByDescending(t => t.NotTarih);
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            yenileRW.IsRefreshing = true;
            ListeGuncelle();
            yenileRW.IsRefreshing = false;

        }

        private void GuncelleSwipeItem_Invoked(object sender, EventArgs e)
        {
            var eleman = (SwipeItem)sender;
            var not = (Notlar)eleman.BindingContext;
            notGirisStackLayout.BindingContext = not;
        }

        private void SilSwipeItem_Invoked(object sender, EventArgs e)
        {
            var eleman = (SwipeItem)sender;
            var not = (Notlar)eleman.BindingContext;
            notGirisStackLayout.BindingContext = not;
        }
    }
}