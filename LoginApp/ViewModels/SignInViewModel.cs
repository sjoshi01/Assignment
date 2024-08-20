using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using LoginApp.Models;
using LoginApp.Views;
using Microsoft.Maui.Storage;

namespace LoginApp.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isSignInButtonEnabled;

        public event PropertyChangedEventHandler PropertyChanged;

        public SignInViewModel()
        {
            SignInCommand = new Command(OnSignIn, () => IsSignInButtonEnabled);
            CreateAccountCommand = new Command(OnCreateAccount);
        }

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                    ValidateInput();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    ValidateInput();
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSignInButtonEnabled
        {
            get => _isSignInButtonEnabled;
            set
            {
                if (_isSignInButtonEnabled != value)
                {
                    _isSignInButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SignInCommand { get; }
        public ICommand CreateAccountCommand { get; }

        private async void OnSignIn()
        {
            ErrorMessage = string.Empty;
            var storedUsername = Preferences.Get("Username", string.Empty);

            if (string.IsNullOrEmpty(storedUsername))
            {
                ErrorMessage = "Account does not exist.";
                return;
            }
            var storedPasswordHash = Preferences.Get("UserPasswordHash", string.Empty);
            Console.WriteLine($"stored password: {storedPasswordHash}");
            var token = Preferences.Get("UserToken", string.Empty);

            var inputPasswordHash = EncryptionHelper.HashPassword(Password, token);
            Console.WriteLine($"stored password: {inputPasswordHash}");
            if (storedPasswordHash != inputPasswordHash)
            {
                ErrorMessage = "Password is incorrect.";
                return;
            }
            ErrorMessage = string.Empty;
            await Application.Current.MainPage.DisplayAlert("Success", $"Welcome, {Username}!", "OK");
            Application.Current.MainPage = new NavigationPage(new SuccessPage(Username));
        }

        private void ValidateInput()
        {
            IsSignInButtonEnabled = !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
            ((Command)SignInCommand).ChangeCanExecute();
        }

        private async void OnCreateAccount()
        {
            Application.Current.MainPage = new NavigationPage(new SignUpPage());
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}