using System.ComponentModel.DataAnnotations;
    
namespace BelissimoCloneWPF.Service.Attributes
{
    public class UserLogin : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string userLogin &&
                 userLogin.All(c => char.IsDigit(c) && c == '_')))
                return new ValidationResult("Username must be only digits and underline");

            return ValidationResult.Success;
        }
    }
}
