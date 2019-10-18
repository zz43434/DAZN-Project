using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> IsUserAuthorized()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("/authorize-user/{clientId}")]
        public IEnumerable<string> AuthorizeUser(Guid clientId)
        {
            return null;
        }
    }
}
