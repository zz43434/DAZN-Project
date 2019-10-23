using System;
using System.Collections.Generic;
using System.Net;
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

        [HttpPost("/open-stream")]
        public async Task<IActionResult> StartStream([FromBody]RequestModel request)
        {
            var authorized = await _authorizationService.IsUserAuthorized(request.UserId);
            var video = await _videoService.GetVideo(request.VideoId);

            if (authorized)
            {
                if (video != null)
                {
                    var stream = await _streamManagementService.RequestStream(request);

                    if (stream != null)
                    {
                        return Ok(stream);
                    }
                    return Ok(HttpStatusCode.TooManyRequests);

                }
                return NotFound();
            }
            return Unauthorized();
        }

        [HttpPost("/close-stream")]
        public async Task<IActionResult> StopStream(Guid streamId)
        {
            var stream = _streamManagementService.DoesStreamExist(streamId);

            if (stream)
            {
                await _streamManagementService.CloseStream(streamId);

                return Ok();
            }
            return NotFound();
        }

        [HttpGet("/all-streams")]
        public async Task<IActionResult> GetStreamsForUserById(Guid userId)
        {
            var streams = await _streamManagementService.CurrentStreams(userId);

            if(streams.Count > 0)
            {
                return Ok(streams);
            }

            return NoContent();
        }
    }
}
