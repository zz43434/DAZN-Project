using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Interfaces;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Services
{
    public class StreamManagementService : IStreamManagementService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private int maxStreams = 3;
        public List<StreamModel> currentStreams = new List<StreamModel>();

        private IVideoService _videoService;
        private IAuthorizationService _authorizationService;

        public StreamManagementService(IVideoService videoService, IAuthorizationService authorizationService)
        {
            _videoService = videoService;
            _authorizationService = authorizationService;
        }

        public async Task<List<VideoModel>> GetStreamContent()
        {
            return await _videoService.GetVideos();
        }

        public async Task<StreamModel> RequestStream(RequestModel request)
        {
            var overStreamLimitCheck = IsUserOverStreamLimit(request.UserId);
            
            if (!overStreamLimitCheck)
            {
                    var stream = new StreamModel
                    {
                        UserId = request.UserId,
                        VideoId = request.VideoId,
                        StreamId = Guid.NewGuid()
                    };

                    currentStreams.Add(stream);

                    return stream;
            }
            return null;
        }

        public async Task CloseStream(Guid streamId)
        {
            var stream = currentStreams.Find(a => a.StreamId == streamId);

            currentStreams.Remove(stream);
        }


        public bool IsUserOverStreamLimit(Guid clientId)
        {
            var streamCount = currentStreams.Count(a => a.UserId == clientId);

            if (streamCount >= maxStreams)
            {
                return true;
            }
            return false;
        }

        public async Task<List<StreamModel>> CurrentStreams(Guid clientId)
        {
            var clientStreams = currentStreams.FindAll(a => a.UserId == clientId);

            return clientStreams;
        }

        public bool DoesStreamExist(Guid streamId)
        {
            var stream = currentStreams.Any(a => a.StreamId == streamId);

            if (stream)
            {
                return true;
            }
            return false;
        }
    }
}
