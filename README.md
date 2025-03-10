# Email OTP System

## Overview
The Email OTP System is a .NET 8 application written in C# that allows users to generate and verify One-Time Passwords (OTPs) sent via email. This system is useful for implementing two-factor authentication (2FA) in applications.

## Features
- Generate OTP and send it to the user's email address.
- Verify the OTP entered by the user.
- Simple console-based user interface.

## Prerequisites
- .NET 8 SDK
- An SMTP server for sending emails

## Getting Started

- Clone the Repository
- Build the Solution
- Run the Application

## Project Structure
- `EmailOTPSystem/Program.cs`: The main entry point of the application.
- `EmailOTPSystem/Models/EmailOTPModule.cs`: Contains the logic for generating and verifying OTPs.
- `EmailOTPSystem/Models/ConsoleInputStream.cs`: Handles console input for OTP verification.
- `EmailOTPSystem/EmailHelper.cs`: Handles Sending Email using SMTP Server.

## Configuration
Before using the system, ensure you have configured your SMTP credentials in the `App.config` file:

## Usage
1. Run the application.
2. Enter your email address when prompted.
3. Check your email for the OTP.
4. Enter the OTP in the console to verify.

## Unit Tests (xUnit)
Unit tests are provided to ensure the functionality of the Email OTP System. The tests cover the following scenarios:

- **OTP Generation**: Verifies that the OTP is generated correctly and meets the expected format.
- **OTP Verification**: Ensures that the OTP entered by the user is correctly verified against the generated OTP.

### Running Unit Tests
To run the unit tests, follow these steps:

1. Open the solution in Visual Studio.
2. Build the solution to ensure all dependencies are resolved.
3. Open the Test Explorer from the `Test` menu.
4. Click `Run All` to execute all unit tests.

The unit tests are located in the `EmailOTPSystem.Tests` project:

- `EmailOTPSystem.Tests/EmailOTPModuleTests.cs`: Contains tests for OTP generation and verification.
- `EmailOTPSystem.Tests/EmailHelperTests.cs`: Contains tests for email sending functionality.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
