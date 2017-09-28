using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Validators
{
    public class EnumNameValidator : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumNameValidator(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Enum.GetNames(_enumType).Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.FormatErrorMessage(validationContext.MemberName));
        }
    }
}
