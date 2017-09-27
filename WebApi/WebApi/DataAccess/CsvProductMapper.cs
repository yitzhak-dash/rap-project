using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class CsvProductMapper : CsvClassMap<Product>
    {
        public CsvProductMapper()
        {
            Map(m => m.Clarity).Name("clarity");
            Map(m => m.Color).Name("color");
            Map(m => m.ListPrice).Name("list price");
            Map(m => m.Price).Name("price");
            Map(m => m.Shape).Name("shape");
            Map(m => m.Size).Name("size");
        }
    }
}
