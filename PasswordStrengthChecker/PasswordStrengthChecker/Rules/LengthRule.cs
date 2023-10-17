namespace PasswordStrengthChecker.Rules
{
    public class LengthRule : IValidationRule
    {
        public bool Validate(string password) => password.Length >= 8;
        public string ErrorMessage => "Password should be at least 8 characters long.";
    }
}
