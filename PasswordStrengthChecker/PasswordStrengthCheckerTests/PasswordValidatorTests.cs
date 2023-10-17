using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PasswordStrengthChecker.Rules;
using PasswordStrengthChecker.Validator;

namespace PasswordStrengthCheckerTests
{
    public class PasswordValidatorTests
    {
        [Theory]
        [InlineData("password123", false)]
        [InlineData("Complex#Passw0rd", true)]
        public void Should_Return_BadRequest_When_Password_Is_Invalid(string password, bool outcome)
        {
            
            
            var mockLengthRule = new Mock<IValidationRule>();
            var mockNumericRule = new Mock<IValidationRule>();
            // ... mock other rules

            // Set up the mock rules to return specific values for testing.
            mockLengthRule.Setup(rule => rule.Validate(It.IsAny<string>())).Returns(true);
            mockNumericRule.Setup(rule => rule.Validate(It.IsAny<string>())).Returns(true);

            var rules = new List<IValidationRule>
            {
                mockLengthRule.Object,
                mockNumericRule.Object
            };

            PasswordValidator validator = new(rules);
            var result = validator.IsValid(password,out List<string> errorMessages);

            if(result)
                errorMessages.Should().BeEmpty();
            else
                errorMessages.Should().NotBeEmpty();
            result.Should().Be(outcome);
        }
    }
}