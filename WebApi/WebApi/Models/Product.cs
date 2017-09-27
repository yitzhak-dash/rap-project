using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        public Shapes Shape { get; set; }

        public double Size { get; set; }

        public char Color { get; set; }

        public ClarityTypes Clarity { get; set; }

        public double Price { get; set; }

        public double ListPrice { get; set; }
    }
}
