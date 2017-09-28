using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class ProductDataProvider : IDataProvider<Product>
    {
        private readonly string _filePath;
        private const string _fileName = "Diamonds.csv";
        private object _lockObject = new object();

        public ProductDataProvider()
        {
            _filePath = GetFilePath();
        }

        private string GetFilePath()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(executableLocation, "DataAccess", _fileName);
        }

        private CsvReader CreateReader(string location)
        {
            var reader = new CsvReader(new StreamReader(location));
            reader.Configuration.RegisterClassMap<CsvProductMapper>();
            return reader;
        }

        private CsvWriter CreateWriter(string location)
        {
            var writer = new CsvWriter(new StreamWriter(location, append: true));
            writer.Configuration.RegisterClassMap<CsvProductMapper>();
            writer.Configuration.ThrowOnBadData = true;
            return writer;
        }

        public bool AddItem(Product item)
        {
            lock (_lockObject)
            {
                using (var writer = CreateWriter(_filePath))
                {
                    writer.WriteField(item.Shape);
                    writer.WriteField(item.Size);
                    writer.WriteField(item.Color);
                    writer.WriteField(item.Clarity);
                    writer.WriteField(item.Price);
                    writer.WriteField(item.ListPrice);
                    writer.NextRecord();
                }
            }
            return true;
        }

        public IEnumerable<Product> GetAll()
        {
            lock (_lockObject)
            {
                using (var reader = CreateReader(_filePath))
                {
                    return reader.GetRecords<Product>().ToList();
                }
            }
        }
    }
}
