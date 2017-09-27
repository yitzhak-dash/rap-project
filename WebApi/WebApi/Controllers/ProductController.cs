using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IDataProvider<Product> _dataProvider;

        public ProductController(IDataProvider<Product> dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        [HttpGet]
        [Route("")]
        public object GetAll()
        {
            return this._dataProvider.GetAll();
        }

        [HttpPost]
        [Route("")]
        public object AddItem([FromBody]Product item)
        {
            return this._dataProvider.AddItem(item);
        }

       
    }
}
