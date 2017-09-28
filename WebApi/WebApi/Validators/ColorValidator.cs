using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
    public class ColorValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var color = (char)value;

            if (Product.COLORS.Contains(color))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.FormatErrorMessage(validationContext.MemberName));
        }
    }
}
