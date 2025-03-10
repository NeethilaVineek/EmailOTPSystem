using EmailOTPSystem.Constants;
using EmailOTPSystem.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPSystem.Test
{
    public class CheckOtp_Tests
    {
        readonly EmailOTPModule emailModule = new();

        [Fact]
        public void Test_CheckOTP_ValidOTP() 
        {
            // Arrange
            var inputMock = new Mock<ConsoleInputStream>();
            var emailModuleMock = new Mock<EmailOTPModule>();
            string currentOtp = GenerateCurrentOTP();

            //Mock GetCurrentOtp method
            emailModuleMock.Setup(x => x.GetCurrentOtp()).Returns(currentOtp);

            //Mock ReadOtp method
            inputMock.SetupSequence(x => x.ReadOtp())
                     .Returns(currentOtp);

            // Act
            var result = emailModuleMock.Object.CheckOtp(inputMock.Object);

            // Assert
            Assert.Equal(StatusCodesConstant.StatusOtpOk, result);
        }

        [Fact]
        public void Test_CheckOTP_InvalidOTP() 
        {
            // Arrange
            var inputMock = new Mock<ConsoleInputStream>();
            var emailModuleMock = new Mock<EmailOTPModule>();
            string currentOtp = GenerateCurrentOTP();

            //Mock GetCurrentOtp method
            emailModuleMock.Setup(x => x.GetCurrentOtp()).Returns(currentOtp);

            inputMock.SetupSequence(x => x.ReadOtp())
                     .Returns("000000")
                     .Returns("111111")
                     .Returns("222222")
                     .Returns("333333")
                     .Returns("444444")
                     .Returns("555555")
                     .Returns("666666")
                     .Returns("777777")
                     .Returns("888888")
                     .Returns("999999");

            // Act
            var result = emailModuleMock.Object.CheckOtp(inputMock.Object);

            // Assert
            Assert.Equal(StatusCodesConstant.StatusOtpFail, result);
        }

        [Fact]
        public void Test_CheckOTP_Timeout() 
        {
            // Arrange
            var inputMock = new Mock<ConsoleInputStream>();
            inputMock.Setup(x => x.ReadOtp())
                     .Callback(() => Thread.Sleep(61000))
                     .Returns("000000");

            // Act
            var result = emailModule.CheckOtp(inputMock.Object);

            // Assert
            Assert.Equal(StatusCodesConstant.StatusOtpTimeout, result);
        }
        private static string GenerateCurrentOTP()
        {
            // Simulate OTP generation
            return "123456";
        }

    }
}
