using NotDefteriVeritabani.Veriler;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefteriVeritabani
{
    public partial class App : Application
    {
       
        static string veritabaniAdi = "notlar.db3";
        static string dosyaYolu = FileSystem.AppDataDirectory;
        static readonly string tamDosyaYolu = Path.Combine(dosyaYolu, veritabaniAdi);

        private static NotlarVeritabani notlarVeritabani;

        public static NotlarVeritabani NotlarVeritabani
        {
            get 
            { 
                if (notlarVeritabani == null)
                {
                    notlarVeritabani = new NotlarVeritabani(tamDosyaYolu);
                }
                return notlarVeritabani;
            }
            
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CollectionViewNotGirisPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
