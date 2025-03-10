using EmailOTPSystem.Models;

namespace EmailOTPSystem;

public class Program
{
    private static void Main()
    {
        EmailOTPModule emailModule = new();
        Console.WriteLine("Enter Email Address");
        var email = Console.ReadLine();

        if (string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Email address cannot be empty.");
        }
        else
        {
            emailModule.Start();

            //Generate OTP and Send Email
            var (isOtpSent, statusCode) = emailModule.GenerateOtpEmail(email);
            Console.WriteLine(statusCode);

            if (isOtpSent)
            {
                //Check OTP
                var checkOtpStatus = emailModule.CheckOtp(new ConsoleInputStream());
                Console.WriteLine(checkOtpStatus);
            }

            emailModule.Close();
        }
    }
}
