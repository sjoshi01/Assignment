Login application

## Features

- **Cross-Platform Support**: Runs on iOS, Android, and macOS.
- **Secure Password Storage**: Passwords are hashed and stored securely using platform-specific mechanisms. Preferences is used to store username and password in local storage.
- **Account Management**: Users can create accounts, sign in, and manage their credentials.


## Project structure
LoginApplication/
├── LoginApp/
│   ├── Platforms/
│   │   ├── Android/
│   │   ├── iOS/
│   │   └── MacCatalyst/
│   ├── Resources/
│   │   ├── Fonts/
│   │   ├── Images/
│   │   ├── Raw/
│   │   └── Styles.xaml           # Added new styles for entry and button
│   ├── ViewModels/
│   │   ├── SignInViewModel.cs     # ViewModel for the sign-in page
│   │   ├── SignUpViewModel.cs     # ViewModel for the sign-up page
│   │   ├── AccountCreatedViewModel.cs # ViewModel for the account created page
│   │   └── SuccessViewModel.cs    # ViewModel for sign-in successful page
│   ├── Views/
│   │   ├── SignInPage.xaml        # XAML for the sign-in page
│   │   ├── SignInPage.xaml.cs     # Code-behind for the sign-in page
│   │   ├── SignUpPage.xaml        # XAML for the sign-up page
│   │   ├── SignUpPage.xaml.cs     # Code-behind for the sign-up page
│   │   ├── AccountCreatedPage.xaml # XAML for the account created page
│   │   ├── AccountCreatedPage.xaml.cs # Code-behind for the account created page
│   │   ├── SuccessPage.xaml       # XAML for the sign-in successful page
│   │   └── SuccessPage.xaml.cs    # Code-behind for the sign-in successful page
│   ├── Models/
│   │   └── UserAccount.cs         # Model for user account data
│   ├── Converters/
│   │   └── StringToBoolConverter.cs # Converter for string to boolean conversion
│   ├── Helper/
│   │   └── EncryptionHelper.cs    # Class for password encryption
│   ├── App.xaml
│   ├── App.xaml.cs
│   └── LoginApp.csproj
└── LoginApplication.sln

