using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using LoginApp.Views;
using Microsoft.Maui.Storage;

namespace LoginApp.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _password;
        private string _confirmPassword;
        private DateTime _serviceStartDate = DateTime.Today;
        private string _errorMessage;
        private bool _isSignUpButtonEnabled;
        
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public DateTime ServiceStartDate
        {
            get => _serviceStartDate;
            set
            {
                _serviceStartDate = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsSignUpButtonEnabled
        {
            get => _isSignUpButtonEnabled;
            set
            {
                _isSignUpButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignUpCommand { get; }
        public ICommand CancelCommand { get; }

        public void ValidateInput()
        {
            try
            {
                ErrorMessage = string.Empty;

                if (string.IsNullOrWhiteSpace(FirstName) ||
                    string.IsNullOrWhiteSpace(LastName) ||
                    string.IsNullOrWhiteSpace(Phone) ||
                    string.IsNullOrWhiteSpace(Password) ||
                    string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    ErrorMessage = "All fields must be filled out.";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                if (ContainsSpecialCharacters(FirstName) || ContainsSpecialCharacters(LastName))
                {
                    ErrorMessage = "First Name and Last Name must not contain special characters (!@#$%^&*).";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                if (!Regex.IsMatch(Phone, @"^\(\d{3}\)-\d{3}-\d{4}$"))
                {
                    ErrorMessage = "Phone number must be in the format (XXX)-XXX-XXXX.";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                if (!IsValidPassword(Password))
                {
                    ErrorMessage = "Password must be 8-15 characters, contain at least one lowercase letter, one uppercase letter, and must not contain repetitive sequences.";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                if (!IsValidConfirmPassword(ConfirmPassword))
                {
                    ErrorMessage = "Password and confirm password must match.";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                if (ServiceStartDate < DateTime.Today)
                {
                    ErrorMessage = "Service Start Date cannot be in the past.";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                if (ServiceStartDate > DateTime.Today.AddDays(30))
                {
                    ErrorMessage = "Service Start Date cannot be more than 30 days in the future This is too early to create an account";
                    IsSignUpButtonEnabled = false;
                    return;
                }

                IsSignUpButtonEnabled = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                IsSignUpButtonEnabled = false;
            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8 || password.Length > 15)
                return false;

            if (!Regex.IsMatch(password, @"[a-z]")) 
                return false;

            if (!Regex.IsMatch(password, @"[A-Z]")) 
                return false;

            if (Regex.IsMatch(password, @"(\w+)\1"))
                return false;

            return true;
        }

        private bool IsValidConfirmPassword(string password)
        {
            if (!password.Equals(Password))
            {
                return false;
            }
            return true;
        }

        private bool ContainsSpecialCharacters(string input)
        {
            return Regex.IsMatch(input, @"[!@#$%^&*]");
        }


        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignUp, () => IsSignUpButtonEnabled);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnCancel()
        {
            Application.Current.MainPage = new NavigationPage(new SignInPage());
        }

        public void ResetForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Phone = string.Empty;
            Password = string.Empty;
            ServiceStartDate = DateTime.Today;
            ErrorMessage = string.Empty;
            IsSignUpButtonEnabled = false;
        }
        private async void OnSignUp()
        {
            if (!IsSignUpButtonEnabled)
            {
                return;
            }
            var token = EncryptionHelper.GenerateToken();
            var hashedPassword = EncryptionHelper.HashPassword(Password, token);
            Console.WriteLine($"What is stored is: {hashedPassword}");
            Preferences.Set("Username", FirstName);
            Preferences.Set("UserToken", token);
            Preferences.Set("UserPasswordHash", hashedPassword);

            await Application.Current.MainPage.DisplayAlert("Success", "Account created successfully!", "OK");
            Application.Current.MainPage = new NavigationPage(new AccountCreatedPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}