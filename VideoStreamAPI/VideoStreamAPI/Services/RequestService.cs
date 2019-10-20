using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Services
{
    public class RequestService
    {
        private AuthorizationService _authorizationService;
        private VideoService _videoService;
        private StreamManagementService _streamManagementService;

        public RequestService(AuthorizationService authorizationService, VideoService videoService, StreamManagementService streamManagementService)
        {
            _authorizationService = authorizationService;
            _videoService = videoService;
            _streamManagementService = streamManagementService;
        }

        public void GetAllVideos()
        {

        }

        public void GetVideo(RequestModel request)
        {

        }

        public void AuthorizeClient()
        {

        }

        public void RequestStream()
        {

        }


    }
}
