using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/type")]
    public class TypesController : ApiController
    {
        [HttpGet]
        [Route("clarity")]
        public object GetClarityTypes()
        {
            return Helper.EnumToEnumarableDynamic<ClarityTypes>();
        }

        [HttpGet]
        [Route("shapes")]
        public object GetShapesTypes()
        {
            return Helper.EnumToEnumarableDynamic<Shapes>();
        }
    }
}


