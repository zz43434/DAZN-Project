using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Services
{
    public class VideoService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public List<VideoModel> GetVideos()
        {
            try
            {
                return allVideos;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public VideoModel GetVideo(Guid videoId)
        {
            try
            {
                return allVideos.Single(a => a.VideoId == videoId);
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        readonly List<VideoModel> allVideos = new List<VideoModel> {
            new VideoModel
            {
                VideoId = Guid.Parse("b1ce21b0-d542-4631-a662-cde3db788f73"),
                VideoLength = 7,
                VideoName = "Test1"
            },
            new VideoModel
            {
                VideoId = Guid.Parse("b86301ea-4086-40e9-82ac-6ca56f74b5b3"),
                VideoLength = 6,
                VideoName = "Test2"
            },
            new VideoModel
            {
                VideoId = Guid.Parse("852c619e-ff88-4597-8966-be180fa345d9"),
                VideoLength = 4,
                VideoName = "Test3"
            },
            new VideoModel
            {
                VideoId = Guid.Parse("198e645e-533b-4e1c-ba91-dd11f305c828"),
                VideoLength = 1,
                VideoName = "Test4"
            }
        };
    }
}
