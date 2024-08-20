using Microsoft.Maui.Controls;
using LoginApp.ViewModels;

namespace LoginApp.Views
{
    public partial class AccountCreatedPage : ContentPage
    {
        public AccountCreatedPage()
        {
            InitializeComponent();
            BindingContext = new AccountCreatedViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new NavigationPage(new SignInPage());
            return true; 
        }
    }
}