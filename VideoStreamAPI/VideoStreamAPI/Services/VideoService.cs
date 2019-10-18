using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Services
{
    public class VideoService
    {
        public List<VideoModel> GetVideos()
        {
            return new List<VideoModel> {
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
}
