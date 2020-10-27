using PeliOne.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PeliOne.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private void OnLoginClicked(object obj)
        {
            App.Current.MainPage = new NavigationPage(new ListPageMain());
        }
    }
}
