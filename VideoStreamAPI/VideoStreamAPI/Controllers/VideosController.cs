using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStreamAPI.Models;
using VideoStreamAPI.Services;

namespace VideoStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {

        private VideoService _videoService;
        private AuthorizationService _authorizationService;
        private StreamManagementService _streamManagementService;

        public VideosController(VideoService videoService, AuthorizationService authorizationService, StreamManagementService streamManagementService)
        {
            _videoService = videoService;
            _authorizationService = authorizationService;
            _streamManagementService = streamManagementService;
        }

        // GET api/values
        [HttpGet("/all-videos")]
        public ActionResult<List<VideoModel>> Get()
        {            
            return _videoService.GetVideos();
        }

        [HttpGet("/{videoId}")]
        public ActionResult<VideoModel> Get(Guid videoId)
        {
            return _videoService.GetVideo(videoId);
        }

        [HttpGet("/{videoId}/{clientId}")]
        public ActionResult<IEnumerable<string>> Get(Guid videoId, Guid clientId)
        {
            return null;
        }
    }
}
