using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelissimoCloneWPF.Service.Attributes
{
    public class UserPassword : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var values = (string)value;
            
            if (!(values is string password && password.Length >= 8 &&
                    password.Any(c => char.IsDigit(c)) &&
                        password.Any(c => char.IsLetter(c))))
                return new ValidationResult("password must be at least one number and at least one letter and number of characters more or equal to 8");


            return ValidationResult.Success;
        }
        
            
            
            
        




        /*if(value is string password && password.Length >= 8 && password.Any(c => char.IsDigit(c)) && password.Any(c => char.IsLetter(c))
        {
            return base.IsValid(value);
        }*/


    }
}
