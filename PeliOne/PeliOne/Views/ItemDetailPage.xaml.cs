using System.ComponentModel;
using Xamarin.Forms;
using PeliOne.ViewModels;

namespace PeliOne.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}