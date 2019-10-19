using System;
using System.Collections.Generic;
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
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

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
            try
            {
                return Ok(_videoService.GetVideos()); 
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        [HttpGet("/video")]
        public ActionResult<string> Get([FromBody]RequestModel request)
        {
            if (IsUserAuthenticated(request.ClientId))
            {
                if (IsUserExceedingStreamLimit(request.ClientId))
                {
                    try
                    {
                        _videoService.GetVideo(request.VideoId);
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.Message);
                        throw;
                    }
                }
                return "Stream limit reached";
            }
            return "User not authorised";
        }

        private bool IsUserAuthenticated(Guid clientId)
        {
            return _authorizationService.IsUserAuthorized(clientId);
        }

        private bool IsUserExceedingStreamLimit(RequestModel request)
        {
            return _streamManagementService.IsClientExceedingStreamLimit(request);
        }
    }
}
