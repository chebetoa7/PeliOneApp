using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PeliOne.Services;
using PeliOne.Views;

namespace PeliOne
{
    public partial class App : Application
    {
        public static string urlApi = "https://api.themoviedb.org/";
        public static string key = "266b1f1010336734c5cad16f255ca1f3";
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();

            MainPage = new NavigationPage(new LoginPage());
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
