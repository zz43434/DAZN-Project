using System;
using VideoStreamAPI.Models;
using VideoStreamAPI.Services;
using Xunit;

namespace VideoStreamTests
{
    public class StreamManagementServiceTest
    {

        [Fact]
        public void DoesStreamExist_Pass()
        {
            var newStream = Guid.NewGuid();

            var streamService = new StreamManagementService();

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

            var streamService = new StreamManagementService();

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

            var streamService = new StreamManagementService();

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

            var streamService = new StreamManagementService();

            streamService.currentStreams.Add(stream);

            Assert.True(streamService.DoesStreamExist(stream.StreamId));

            streamService.CloseStream(stream.StreamId);

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

            var streamService = new StreamManagementService();

            streamService.currentStreams.Add(stream);
            Assert.False(streamService.IsUserOverStreamLimit(stream.UserId));
            streamService.currentStreams.Add(stream);
            Assert.False(streamService.IsUserOverStreamLimit(stream.UserId));
            streamService.currentStreams.Add(stream);
            Assert.True(streamService.IsUserOverStreamLimit(stream.UserId));

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

            var streamService = new StreamManagementService();

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

            var streamService = new StreamManagementService();

            streamService.currentStreams.Add(stream);
            Assert.True(streamService.DoesStreamExist(stream.StreamId));

            streamService.CloseStream(stream.StreamId);
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

            var streamService = new StreamManagementService();
            
            streamService.CloseStream(stream.StreamId);
            Assert.False(streamService.DoesStreamExist(stream.StreamId));
        }
    }
}
