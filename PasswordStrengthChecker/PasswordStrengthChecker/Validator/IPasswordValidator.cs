namespace PasswordStrengthChecker.Validator
{
    public interface IPasswordValidator
    {
        bool IsValid(string password, out List<string> errorMessages);
    }
}