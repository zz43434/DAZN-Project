using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStreamer.Models;

namespace VideoStreamer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        // GET api/values
        [HttpGet("/all-videos")]
        public IActionResult GetAllVideos()
        {
            return null;
        }

        [HttpGet("/{videoId}/{clientId}")]
        public async Task<FileStreamResult> GetVideo(Guid videoId, Guid clientId)
        {
            return null;
        }
    }
}
