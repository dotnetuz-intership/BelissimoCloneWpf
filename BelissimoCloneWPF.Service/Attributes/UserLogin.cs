using System.ComponentModel.DataAnnotations;
    
namespace BelissimoCloneWPF.Service.Attributes
{
    public class UserLogin : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string Login &&
                 Login.All(c => char.IsDigit(c) && c == '_')))
                return new ValidationResult("username must be only digits and underline");

            return ValidationResult.Success;
        }
    }
}
