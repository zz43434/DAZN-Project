using System;
using System.Collections.Generic;
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
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public VideosController(VideoService videoService, AuthorizationService authorizationService, StreamManagementService streamManagementService)
        {
            _videoService = videoService;
            _authorizationService = authorizationService;
            _streamManagementService = streamManagementService;
        } 

        // GET api/values
        [HttpGet("/all-videos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _videoService.GetVideos();
                return Ok(result); 
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("/video")]
        public async Task<IActionResult> Get([FromBody]RequestModel request)
        {
            //if (IsUserAuthenticated(request.ClientId))
            //{
            //    if (IsUserExceedingStreamLimit(request))
            //    {
            //        try
            //        {
            //            var result = await _videoService.GetVideo(request.VideoId);
            //            return Ok(result);
            //        }
            //        catch (Exception ex)
            //        {
            //            _logger.Error(ex.Message);
            //            throw;
            //        }
            //    }
            //    throw new Exception("Stream limit reached");
            //}
            throw new Exception("User not authorised");
        }

        private Task<string> IsUserAuthenticated(Guid clientId)
        {
            var authorized = await _authorizationService.IsUserAuthorized(clientId);
            return authorized;
        }

        private bool IsUserExceedingStreamLimit(RequestModel request)
        {
            return _streamManagementService.IsClientExceedingStreamLimit(request.ClientId);
        }
    }
}
