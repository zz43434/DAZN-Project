using System;
using System.Collections.Generic;
using System.Linq;
using VideoStreamAPI.Models;
using Xunit;

namespace VideoStreamTests
{
    public class VideoServiceTest
    {
        [Fact]
        public void ReturnAllVideos_Pass()
        {
            var result = allVideos;

            Assert.Equal(result, allVideos);
        }

        [Fact]
        public void ReturnSingleVideo_Pass()
        {
            var result = allVideos.SingleOrDefault();

            Assert.IsType<VideoModel>(result);
            Assert.Single<VideoModel>(result);
        }

        [Fact]
        public void ReturnVideoFromGUID_Pass()
        {

        }

        [Fact]
        public void ReturnVideoNotFoundError_Pass() { }

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
