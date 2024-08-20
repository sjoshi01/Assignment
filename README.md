## Overview
The MatrixMultiplication project is a C# console application designed to retrieve two-dimensional datasets from an external service, multiply them as matrices, and then validate the result by computing an MD5 hash. The project demonstrates matrix operations, interaction with an external API, and validation of computed results.

## Features
Matrix Initialization: Initialize datasets from an external API.
Matrix Multiplication: Perform multiplication on large matrices using optimized parallel processing.
Result Validation: Compute an MD5 hash of the result matrix and validate it against the external API.

##Project Structure
```Plain text
MatrixMultiplication/
├── MatrixMultiplication.csproj  
├── Program.cs                   
├── Interfaces/
│   ├── IMatrixService.cs        # Interface for matrix service
│   ├── IMatrixMultiplier.cs     # Interface for matrix multiplication
│   ├── IResultService.cs        # Interface for result service
|__ Services
│   ├── MatrixService.cs         # Implementation of matrix service
│   ├── MatrixMultiplier.cs      # Implementation of matrix multiplication
│   └── ResultService.cs         # Implementation of result service
├── Models/
│   ├── InitResponse.cs          # Model for initial size response
│   ├── MatrixRowOrColumnResponse.cs     # Model for matrix data response 
└── README.md                    # Project documentation
```

## Output
Runtime taken is 14.4161794 seconds
