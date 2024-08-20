using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using LoginApp.Views;

namespace LoginApp.ViewModels
{
    public class SuccessViewModel : INotifyPropertyChanged
    {
        private string _welcomeMessage;

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignOutCommand { get; }

        public SuccessViewModel(string username)
        {
            WelcomeMessage = $"Welcome, {CapitalizeFirstLetter(username)}!";
            SignOutCommand = new Command(OnSignOut);
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return $"{input.Substring(0, 1).ToUpperInvariant()}{input.Substring(1).ToLowerInvariant()}";
        }

        private async void OnSignOut()
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