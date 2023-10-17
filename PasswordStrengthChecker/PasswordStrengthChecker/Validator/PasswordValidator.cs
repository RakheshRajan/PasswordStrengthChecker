using Microsoft.OpenApi.Validations;
using PasswordStrengthChecker.Rules;

namespace PasswordStrengthChecker.Validator
{

    public class PasswordValidator : IPasswordValidator
    {
        private readonly IEnumerable<IValidationRule> _rules;

        public PasswordValidator(IEnumerable<IValidationRule> rules)
        {
            _rules = rules;
        }

        public bool IsValid(string password, out List<string> errorMessages)
        {
            errorMessages = new List<string>();

            foreach (var rule in _rules)
            {
                if (!rule.Validate(password))
                {
                    errorMessages.Add(rule.ErrorMessage);
                }
            }

            return !errorMessages.Any();
        }
    }
}
