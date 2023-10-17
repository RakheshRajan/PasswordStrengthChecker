namespace PasswordStrengthChecker.Rules
{
    public class UppercaseRule : IValidationRule
    {
        public bool Validate(string password) => password.Any(char.IsUpper);
        public string ErrorMessage => "Password should contain at least one uppercase letter.";
    }
}
