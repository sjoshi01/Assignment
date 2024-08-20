using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using LoginApp.Views;

namespace LoginApp.ViewModels
{
    public class AccountCreatedViewModel : INotifyPropertyChanged
    {
        public ICommand SignInCommand { get; }

        public AccountCreatedViewModel()
        {
            SignInCommand = new Command(OnSignIn);
        }

        private async void OnSignIn()
        {
            Application.Current.MainPage = new NavigationPage(new SignInPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}