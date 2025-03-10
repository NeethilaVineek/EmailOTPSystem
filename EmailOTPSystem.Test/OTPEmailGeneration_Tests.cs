using EmailOTPSystem.Constants;
using EmailOTPSystem.Test.Fixture;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EmailOTPSystem.Test
{
    public class OTPEmailGeneration_Tests 
    {
        [Theory]
        [MemberData(nameof(EmailOtp_Test_Cases.TestData), MemberType = typeof(EmailOtp_Test_Cases))]
        public void Test_OTPEmailGeneration(EmailOtp_Test_Cases fixture)   
        {
            // Arrange
            var emailServiceMock = new Mock<EmailOTPModule>();
            emailServiceMock.Setup(x => x.SendEmail(It.IsAny<string>())).Returns((true, StatusCodesConstant.StatusEmailOk));
            var emailOtpModule = emailServiceMock.Object;

            // Act
            (bool isOtpSent, string statusCode) = emailOtpModule.GenerateOtpEmail(fixture.EmailAddress);

            // Assert
            Assert.Equal(fixture.ExpectedStatusCode, statusCode);
            Assert.Equal(fixture.ExpectedResult, isOtpSent);
        }

    }

}