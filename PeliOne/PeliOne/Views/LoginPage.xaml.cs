using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliOne.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeliOne.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        #region Builder
        public LoginPage()
        {
            InitializeComponent();
            LoadPageContent();
            this.BindingContext = new LoginViewModel();
        }
        #endregion

        #region Methods

        //Carga todos los datos iniciales
        public void LoadPageContent() 
        {
            try 
            {
                nameTitle.Text = "PeliOne";
            } catch (Exception exM) 
            {
                Console.WriteLine("Error verificar: \n" + exM.Message + "\n");
            }
        }
        #endregion
    }
}