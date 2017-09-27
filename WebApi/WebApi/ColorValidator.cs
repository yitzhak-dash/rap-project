using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class ColorValidator : ValidationAttribute
    {
        private readonly char[] colors = "DEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var color = (char)value;

            if (colors.Contains(color))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.FormatErrorMessage(validationContext.MemberName));
        }
    }
}
