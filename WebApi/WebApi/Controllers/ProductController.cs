using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.DataAccess;
using WebApi.Filters;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IDataProvider<Product> _dataProvider;

        public ProductController(IDataProvider<Product> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        [Route("")]
        public object GetAll()
        {
            try
            {
                var data = _dataProvider.GetAll().ToList();
                return data;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        [ValidateModel]
        public HttpResponseMessage AddItem(Product item)
        {
            // TODO: validate input same items
            try
            {
                _dataProvider.AddItem(item);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
