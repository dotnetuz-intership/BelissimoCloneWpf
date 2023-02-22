using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.Attributes
{
    public class FormFileAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var path = (string)value;

            if (!File.Exists(path))
                return new ValidationResult("File not found.");

            string[] extensions = new string[]{".png", ".jpg", ".ico"};         
            var extension = Path.GetExtension(path);

            if (!extensions.Contains(extension))
            {
                return new ValidationResult("This photo extension is not allowed! Allowed extensions is png, jpg, ico");
            }

            return ValidationResult.Success;
        }
    }
}
