using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamAPI.Interfaces;
using VideoStreamAPI.Models;
using VideoStreamAPI.Services;
using Xunit;

namespace VideoStreamTests
{
    public class StreamManagementServiceTest
    {
        private Mock<IAuthorizationService> _authServiceMock;
        private Mock<IVideoService> _videoServiceMock;

        public StreamManagementServiceTest()
        {
            _authServiceMock = new Mock<IAuthorizationService>();
            _videoServiceMock = new Mock<IVideoService>();
        }

        [Fact]
        public async void DoesStreamExist_Pass()
        {
            var newStream = Guid.NewGuid();

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            var results = new StreamModel
            {
                UserId = Guid.NewGuid(),
                VideoId = Guid.NewGuid(),
                StreamId = newStream
            };

            streamService.currentStreams.Add(results);
            
            var result = streamService.DoesStreamExist(newStream);

            Assert.True(result);
        }

        [Fact]
        public void DoesStreamExist_Fail()
        {
            var newStream = Guid.NewGuid();

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            var result = streamService.DoesStreamExist(newStream);

            Assert.False(result);
        }

        [Fact]
        public async void CreateStream_Pass()
        {
            var user = Guid.NewGuid();

            var video = new VideoModel
            {
                VideoId = Guid.NewGuid(),
                VideoLength = 7,
                VideoName = "Test"
            };
            
            var request = new RequestModel
            {
                VideoId = video.VideoId,
                UserId = user
            };
            
            _authServiceMock.Setup(a => a.IsUserAuthorized(user)).ReturnsAsync(true);
            _videoServiceMock.Setup(a => a.GetVideo(video.VideoId)).ReturnsAsync(video);

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            var result = await streamService.RequestStream(request);

            var streamId = streamService.currentStreams.Find(a => a.UserId == user);
            
            var stream = new StreamModel
            {
                UserId = user,
                VideoId = video.VideoId,
                StreamId = streamId.StreamId
            };

            Assert.NotStrictEqual(stream, result);
        }

        [Fact]
        public async void DeleteStream_Pass()
        {
            var stream = new StreamModel
            {
                StreamId = Guid.NewGuid(),
                VideoId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            streamService.currentStreams.Add(stream);

            Assert.True(streamService.DoesStreamExist(stream.StreamId));

            await streamService.CloseStream(stream.StreamId);

            Assert.False(streamService.DoesStreamExist(stream.StreamId));
        }

        [Fact]
        public void StreamCount_Pass()
        {
            var stream = new StreamModel
            {
                StreamId = Guid.NewGuid(),
                VideoId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            streamService.currentStreams.Add(stream);
            Assert.False(streamService.IsUserOverStreamLimit(stream.UserId));
            streamService.currentStreams.Add(stream);
            Assert.False(streamService.IsUserOverStreamLimit(stream.UserId));
            streamService.currentStreams.Add(stream);
            Assert.False(streamService.IsUserOverStreamLimit(stream.UserId));

        }

        [Fact]
        public void StreamCount_Fail()
        {
            var stream = new StreamModel
            {
                StreamId = Guid.NewGuid(),
                VideoId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            streamService.currentStreams.Add(stream);
            streamService.currentStreams.Add(stream);
            streamService.currentStreams.Add(stream);
            streamService.currentStreams.Add(stream);
            Assert.True(streamService.IsUserOverStreamLimit(stream.UserId));
        }

        [Fact]
        public async void StopStream_Pass()
        {
            var stream = new StreamModel
            {
                StreamId = Guid.NewGuid(),
                VideoId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);

            streamService.currentStreams.Add(stream);
            Assert.True(streamService.DoesStreamExist(stream.StreamId));

            await streamService.CloseStream(stream.StreamId);
            Assert.False(streamService.DoesStreamExist(stream.StreamId));
        }

        [Fact]
        public async void StopStream_Fail()
        {
            var stream = new StreamModel
            {
                StreamId = Guid.NewGuid(),
                VideoId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            var streamService = new StreamManagementService(_videoServiceMock.Object, _authServiceMock.Object);
            
            await streamService.CloseStream(stream.StreamId);
            Assert.False(streamService.DoesStreamExist(stream.StreamId));
        }
    }
}
