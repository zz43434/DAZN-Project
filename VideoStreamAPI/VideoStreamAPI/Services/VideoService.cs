using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Interfaces;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Services
{
    public class VideoService : IVideoService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public async Task<List<VideoModel>> GetVideos()
        {
            try
            {
                return allVideos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw new Exception("Unable to retrieve all videos");
            }
        }

        public async Task<VideoModel> GetVideo(Guid videoId)
        {
            try
            {
                var video = allVideos.Any(a => a.VideoId == videoId);

                if (video)
                {
                    return allVideos.Single(a => a.VideoId == videoId);
                }
                return null;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                throw new Exception("Unable to retrieve video");
            }
        }
        
        readonly List<VideoModel> allVideos = new List<VideoModel> {
            new VideoModel
            {
                VideoId = Guid.NewGuid(),
                VideoLength = 7,
                VideoName = "Test1"
            },
            new VideoModel
            {
                VideoId = Guid.NewGuid(),
                VideoLength = 6,
                VideoName = "Test2"
            },
            new VideoModel
            {
                VideoId = Guid.NewGuid(),
                VideoLength = 4,
                VideoName = "Test3"
            },
            new VideoModel
            {
                VideoId = Guid.NewGuid(),
                VideoLength = 1,
                VideoName = "Test4"
            }
        };
    }
}
