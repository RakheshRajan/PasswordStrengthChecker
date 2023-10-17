using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using PasswordStrengthChecker.Validator;
using System.ComponentModel.DataAnnotations;

namespace PasswordStrengthChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordStrengthController : ControllerBase
    {

        private readonly ILogger<PasswordStrengthController> _logger;
        private readonly IPasswordValidator _passwordValidator;

        public PasswordStrengthController(ILogger<PasswordStrengthController> logger, IPasswordValidator passwordValidator)
        {
            _logger = logger;
            _passwordValidator = passwordValidator;            
        }

        [HttpPost]
        public ActionResult ValidatePassword([FromBody] PasswordRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Password is required");
            }

            if (_passwordValidator.IsValid(request.Password, out var errorMessages))
            {
                return Ok(new { IsValid = true });
            }

            _logger.Log(LogLevel.Information, "", new { IsValid = false, Errors = errorMessages });
            return BadRequest(new { IsValid = false, Errors = errorMessages });
        }
        
        public class PasswordRequest
        {
            public required string Password { get; set; }
        }
    }
}