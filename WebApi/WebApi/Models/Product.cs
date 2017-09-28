using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Validators;

namespace WebApi.Models
{
    public class Product
    {
        public static readonly char[] COLORS = "DEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        [Required]
        [EnumNameValidator(typeof(Shapes))]
        public string Shape { get; set; }

        [Required]
        public double? Size { get; set; }

        [Required]
        [ColorValidator]
        public char? Color { get; set; }

        [Required]
        [EnumNameValidator(typeof(ClarityTypes))]
        public string Clarity { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public double? ListPrice { get; set; }
    }
}
