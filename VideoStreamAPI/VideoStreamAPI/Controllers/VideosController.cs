using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        // GET api/values
        [HttpGet("/all-videos")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet("/{videoId}/{clientId}")]
        public ActionResult<IEnumerable<string>> Get(Guid videoId, Guid clientId)
        {
            return null;
        }
    }
}
