using System;
using System.Collections.Generic;
using System.Linq;
using VideoStreamAPI.Models;
using VideoStreamAPI.Interfaces;
using Xunit;
using VideoStreamAPI.Services;

namespace VideoStreamTests
{
    public class VideoServiceTest
    {

        private VideoService _videoService = new VideoService();

        [Fact]
        public void ReturnAllVideos_Pass()
        {
            var allVideos = _videoService.GetVideos();

            Assert.IsType<List<VideoModel>>(allVideos.Result);
            Assert.NotEmpty(allVideos.Result);
        }

        [Fact]
        public void ReturnVideoFromGUID_Pass()
        {
            var allVideos = _videoService.GetVideos();
            
            var video = allVideos.Result[0];

            var result = _videoService.GetVideo(video.VideoId);
            
            Assert.IsType<VideoModel>(result.Result);
        }

        [Fact]
        public void ReturnVideoFromGUID_Fail()
        {
            var video = Guid.NewGuid();

            var result = _videoService.GetVideo(video);

            Assert.Null(result.Result);
        }
    }
}
