using EmailOTPSystem.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPSystem.Test.Fixture
{
    public class EmailOtp_Test_Cases
    {
        public required string Name { get; set; }
        public required string EmailAddress { get; set; }
        public required string ExpectedStatusCode { get; set; } 
        public required bool ExpectedResult { get; set; } 

        public static readonly object[][] TestData =
        [
                [
                    new EmailOtp_Test_Cases
                    {
                        Name = "When Email Address is valid - Positive",
                        EmailAddress =  "user1@dso.org.sg",
                        ExpectedStatusCode = StatusCodesConstant.StatusEmailOk,
                        ExpectedResult = true,
                    }
                ],
                [
                    new EmailOtp_Test_Cases
                    {
                        Name = "When Email Address is valid - Positive",
                        EmailAddress =  "user2@dso.org.sg",
                        ExpectedStatusCode = StatusCodesConstant.StatusEmailOk,
                        ExpectedResult = true,
                    }
                ],
                [
                    new EmailOtp_Test_Cases
                    {
                        Name = "When Email Address is Invalid - Negative",
                        EmailAddress =  "user3@xxx.org.sg",
                        ExpectedStatusCode = StatusCodesConstant.StatusEmailInvalid,
                        ExpectedResult = false,
                    }
                ],
                [
                    new EmailOtp_Test_Cases
                    {
                        Name = "When Email Address is Invalid - Negative",
                        EmailAddress =  "user5@gmail.com",
                        ExpectedStatusCode = StatusCodesConstant.StatusEmailInvalid,
                        ExpectedResult = false,
                    }
                ]
        ];
    }
}
