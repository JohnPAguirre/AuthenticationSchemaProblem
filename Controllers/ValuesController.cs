using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AuthenticationSchemaProblem.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values/Works
        [HttpGet]
        [Route("Works")]
        [Authorize(ActiveAuthenticationSchemes = "BasicAuth")]
        public string Works()
        {
            return "works";
        }

        // GET api/values/DoesNotWork
        [HttpGet]
        [Route("DoesNotWork")]
        [Authorize]
        public string DoesNotWork()
        {
            return "does not work";
        }
        
    }
}
