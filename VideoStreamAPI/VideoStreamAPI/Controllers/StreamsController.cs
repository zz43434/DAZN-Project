using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStreamAPI.Interfaces;
using VideoStreamAPI.Models;
using VideoStreamAPI.Services;

namespace VideoStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamsController : ControllerBase
    {

        private IVideoService _videoService;
        private IAuthorizationService _authorizationService;
        private IStreamManagementService _streamManagementService;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public StreamsController(IVideoService videoService, IAuthorizationService authorizationService, IStreamManagementService streamManagementService)
        {
            _videoService = videoService;
            _authorizationService = authorizationService;
            _streamManagementService = streamManagementService;
        } 

        [HttpGet("/stream-content")]
        public async Task<IActionResult> GetStreamContent()
        {
            
            var content = await _videoService.GetVideos();

            if (content.Count > 0)
            {
                return Ok(content);
            }

            return NoContent();
        }

        [HttpGet("/open-stream")]
        public async Task<IActionResult> StartStream([FromBody]RequestModel request)
        {
            var stream = await _streamManagementService.RequestStream(request);

            return Ok(stream);
        }

        [HttpGet("/close-stream")]
        public async Task<IActionResult> StopStream(Guid streamId)
        {
            await _streamManagementService.CloseStream(streamId);

            return Ok();
        }
    }
}
