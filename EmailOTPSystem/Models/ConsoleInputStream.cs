using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPSystem.Models
{
    public class ConsoleInputStream : IOStream
    {
        public virtual string ReadOtp()
        {
            string otp;

            Console.Write("Please enter the 6-digit OTP: ");
            otp = Console.ReadLine() ?? string.Empty;
            return otp;
        }
    }

}
