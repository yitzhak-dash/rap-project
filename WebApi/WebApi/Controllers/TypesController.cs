using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/type")]
    public class TypesController : ApiController
    {
        [HttpGet]
        [Route("clarity")]
        public object GetClarityTypes()
        {
            return Enum.GetNames(typeof(ClarityTypes));
        }

        [HttpGet]
        [Route("shape")]
        public object GetShapesTypes()
        {
            return Enum.GetNames(typeof(Shapes));
        }

        [HttpGet]
        [Route("color")]
        public object GetColorTypes()
        {
            return Product.COLORS;
        }
    }
}


