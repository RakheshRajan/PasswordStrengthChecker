namespace PasswordStrengthChecker.Rules
{
    public interface IValidationRule
    {
        string ErrorMessage { get; }

        bool Validate(string password);
    }
}
