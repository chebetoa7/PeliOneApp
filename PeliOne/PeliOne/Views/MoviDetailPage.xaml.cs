using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeliOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviDetailPage : ContentPage
    {
        public MoviDetailPage()
        {
            InitializeComponent();
            Cargar();
        }

        public void Cargar() 
        {
            try 
            {
                var det = MainPageMovi.dataDetail.Count();
                if (det != 0) 
                {
                    imgPoster.Source = "https://image.tmdb.org/t/p/w500/" + MainPageMovi.dataDetail.First().backdrop_path.ToString();
                    lblName.Text = MainPageMovi.dataDetail.First().original_title.ToString() + ", " + 
                        MainPageMovi.dataDetail.First().original_language.ToString();
                    lblDes.Text = MainPageMovi.dataDetail.First().overview.ToString();
                }
            } catch (Exception exM)
            {
                Console.WriteLine(exM.Message + "\n");
            }
        }
    }
}