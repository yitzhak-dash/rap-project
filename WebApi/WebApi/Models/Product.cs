using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        [Required]
        public Shapes? Shape { get; set; }

        [Required]
        public double? Size { get; set; }

        [Required]
        [ColorValidator]
        public char? Color { get; set; }

        [Required]
        public ClarityTypes? Clarity { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public double? ListPrice { get; set; }
    }
}
