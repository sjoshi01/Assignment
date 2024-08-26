## Login application

## Features

- **Cross-Platform Support**: Runs on iOS, Android, and macOS.
- **Secure Password Storage**: Passwords are hashed and stored securely using platform-specific mechanisms. Preferences is used to store username and password in local storage.
- **Account Management**: Users can create accounts, sign in, and manage their credentials.

## Matrix Multiplication

## Overview
The MatrixMultiplication project is a C# console application designed to retrieve two-dimensional datasets from an external service, multiply them as matrices, and then validate the result by computing an MD5 hash. The project demonstrates matrix operations, interaction with an external API, and validation of computed results.

## Features
Matrix Initialization: Initialize datasets from an external API.
Matrix Multiplication: Perform multiplication on large matrices using optimized parallel processing.
Result Validation: Compute an MD5 hash of the result matrix and validate it against the external API.
![ios_sign_in](https://github.com/user-attachments/assets/b32792b4-82de-4c96-9b9a-7377b9b9ea24)
![ios_create_account_error1](https://github.com/user-attachments/assets/65c5def8-82c5-44fd-b877-0a9c59782670)
![ios_sign_in_success](https://github.com/user-attachments/assets/ed1a06ff-ad0c-42a0-ade1-316c9f871007)
![ios_sign_in_success](https://github.com/user-attachments/assets/ea506551-dc99-4fb7-97cf-a9da1e303a44)

![Android_account created](https://github.com/user-attachments/assets/c94b8699-4087-465b-8e37-01014a6c71c7)

![Android_create_account_form](https://github.com/user-attachments/assets/c87901fb-da7e-41e7-b65f-32de348f754f)

![Android_create account](https://github.com/user-attachments/assets/9759787e-f663-490b-8e8b-544148695926)

<img width="621" alt="Screenshot 2024-08-20 at 1 55 16 AM" src="https://github.com/user-attachments/assets/192425d9-4ba8-41b7-8736-a30e95c815ba">

<img width="317" alt="Screenshot 2024-08-20 at 1 40 43 AM" src="https://github.com/user-attachments/assets/9a9c014c-2e72-400f-b3f5-3c9dccfff092">

## Project structure
```plaintext
Assignment/
├──LoginApplication/
│   ├── LoginApp/
│   │   ├── Platforms/
│   │   │   ├── Android/
│   │   │   ├── iOS/
│   │   │   └── MacCatalyst/
│   │   ├── Resources/
│   │   │   ├── Fonts/
│   │   │   ├── Images/
│   │   │   ├── Raw/
│   │   │   └── Styles.xaml           # Added new styles for entry and button
│   │   ├── ViewModels/
│   │   │   ├── SignInViewModel.cs     # ViewModel for the sign-in page
│   │   │   ├── SignUpViewModel.cs     # ViewModel for the sign-up page
│   │   │   ├── AccountCreatedViewModel.cs # ViewModel for the account created page
│   │   │   └── SuccessViewModel.cs    # ViewModel for sign-in successful page
│   │   ├── Views/
│   │   │   ├── SignInPage.xaml        # XAML for the sign-in page
│   │   │   ├── SignInPage.xaml.cs     # Code-behind for the sign-in page
│   │   │   ├── SignUpPage.xaml        # XAML for the sign-up page
│   │   │   ├── SignUpPage.xaml.cs     # Code-behind for the sign-up page
│   │   │   ├── AccountCreatedPage.xaml # XAML for the account created page
│   │   │   ├── AccountCreatedPage.xaml.cs # Code-behind for the account created page
│   │   │   ├── SuccessPage.xaml       # XAML for the sign-in successful page
│   │   │   └── SuccessPage.xaml.cs    # Code-behind for the sign-in successful page
│   │   ├── Models/
│   │   │   └── UserAccount.cs         # Model for user account data
│   │   ├── Converters/
│   │   │   └── StringToBoolConverter.cs # Converter for string to boolean conversion
│   │   ├── Helper/
│   │   │   └── EncryptionHelper.cs    # Class for password encryption
│   │   ├── App.xaml
│   │   ├── App.xaml.cs
│   │   └── LoginApp.csproj
├── MatrixMultiplication/
│   ├── MatrixMultiplication.csproj  
│   ├── Program.cs                   
│   │   ├── Interfaces/
│   │   │   ├── IMatrixService.cs        # Interface for matrix service
│   │   │   ├── IMatrixMultiplier.cs     # Interface for matrix multiplication
│   │   │   ├── IResultService.cs        # Interface for result service
│   |__ Services
│   │   │   ├── MatrixService.cs         # Implementation of matrix service
│   │   │   ├── MatrixMultiplier.cs      # Implementation of matrix multiplication
│   │   │   ├── ResultService.cs         # Implementation of result service
│   ├── Models/
│   │   │   ├── InitResponse.cs          # Model for initial size response
│   │   │   ├── MatrixRowOrColumnResponse.cs     # Model for matrix data response
├── MatrixMultiplication.Tests/
│   ├── MatrixMultiplication.Tests.csproj
│   ├── MatrixMultiplierTests.cs
│   ├── MatrixServiceTests.cs
│   ├── ResultServiceTests.cs
│   ├── MockHttpMessageHandler.cs
└── AssignmentSolution.sln
└── README.md                    # Project documentation
```

## Output
Runtime taken is 14.4161794 seconds
