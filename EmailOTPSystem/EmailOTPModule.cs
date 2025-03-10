using EmailOTPSystem.Constants;
using EmailOTPSystem.Models;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace EmailOTPSystem
{
    public class EmailOTPModule
    {
        private const string Domain = "dso.org.sg";
        private const int OtpLength = 6;
        private const int OtpValidityDuration = 60000; // 1 minute in milliseconds
        private const int MaxAttempts = 10;
        private string? currentOtp;
        private DateTime otpGenerationTime;

        public void Start()
        {
            currentOtp = string.Empty;
            otpGenerationTime = default;
        }
        public (bool isOtpSent, string statusCode) GenerateOtpEmail(string userEmail)
        {
            if (!IsValidEmail(userEmail) || !userEmail.EndsWith(Domain))
            {
                return (false, StatusCodesConstant.StatusEmailInvalid);
            }

            GenerateOtp();
            otpGenerationTime = DateTime.Now;
            return SendEmail(userEmail);
        }
        public void GenerateOtp()
        {
            var otpBytes = new byte[OtpLength];
            RandomNumberGenerator.Fill(otpBytes);
            var otpBuilder = new StringBuilder(OtpLength);
            foreach (var b in otpBytes)
            {
                otpBuilder.Append(b % 10);
            }
            currentOtp = otpBuilder.ToString();
        }
        public string CheckOtp(IOStream input)
        {
            int attempts = 0;
            var timeoutTask = Task.Delay(OtpValidityDuration);
            while (attempts < MaxAttempts)
            {
                var otpTask = Task.Run(() => input.ReadOtp());
                if (Task.WhenAny(otpTask, timeoutTask).Result == timeoutTask)
                {
                    return StatusCodesConstant.StatusOtpTimeout;
                }

                string userOtp = otpTask.Result;
                if (userOtp == GetCurrentOtp())
                {
                    return StatusCodesConstant.StatusOtpOk;
                }
                attempts++;
            }

            return StatusCodesConstant.StatusOtpFail;
        }
        public void Close()
        {
            // Reset OTP and clear sensitive data
            currentOtp = string.Empty;
            otpGenerationTime = default;
        }
        public virtual (bool isOtpSent, string statusCode) SendEmail(string userEmail)
        {
            string emailBody = $"Your OTP Code is {currentOtp}. The code is valid for 1 minute";
            bool emailSent = EmailHelper.SendEmail(userEmail, emailBody);

            return emailSent ? (true, StatusCodesConstant.StatusEmailOk) : (false, StatusCodesConstant.StatusEmailFail);
        }
        public virtual string? GetCurrentOtp()
        {
            return currentOtp;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}