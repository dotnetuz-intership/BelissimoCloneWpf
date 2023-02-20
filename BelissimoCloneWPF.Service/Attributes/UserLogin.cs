using System.ComponentModel.DataAnnotations;

namespace BelissimoCloneWPF.Service.Attributes
{
    public class UserLogin : ValidationAttribute
    {
        public override bool IsValid(object value)
            => value is string login &&
             login.All(c => char.IsDigit(c) ||
             c == '_');       
    }
}
