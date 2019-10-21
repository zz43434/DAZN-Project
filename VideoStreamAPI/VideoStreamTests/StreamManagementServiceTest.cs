using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamAPI.Interfaces;
using Xunit;

namespace VideoStreamTests
{
    public class StreamManagementServiceTest
    {
        private IStreamManagementService _streamManagementService;

        public StreamManagementServiceTest(IStreamManagementService streamManagementService)
        {
            _streamManagementService = streamManagementService;
        }

        [Fact]
        public void DoesStreamExist_Pass()
        {
            var newStream = Guid.NewGuid();

            _streamManagementService.StartStream(newStream);

            var result = _streamManagementService.DoesStreamExist(newStream);

            Assert.True(result);
        }

        [Fact]
        public void DoesStreamExist_Fail() { }

        [Fact]
        public void CreateStream_Pass()
        {
            var user = Guid.NewGuid();

            var result = _streamManagementService.StartStream(user);

            var check = _streamManagementService.DoesStreamExist(result);

            Assert.False(check);
        }

        [Fact]
        public void DeleteStream_Pass()
        {
            var user = Guid.NewGuid();

            var stream = _streamManagementService.StartStream(user);

            var check = _streamManagementService.DoesStreamExist(stream);

            _streamManagementService.StopStream(stream);

            check = _streamManagementService.DoesStreamExist(stream);

            Assert.False(check);
        }

        [Fact]
        public void StreamCount_Pass()
        {
            var user = Guid.NewGuid();
            _streamManagementService.StartStream(user);
            _streamManagementService.StartStream(user);

            var count = _streamManagementService.CurrentStreams(user);

            Assert.True(count.Count == 2);
        }

        [Fact]
        public void StopStream_Pass()
        {
            var user = Guid.NewGuid();
            var result = _streamManagementService.StartStream(user);
            var check = _streamManagementService.DoesStreamExist(result);

            Assert.True(check);

            _streamManagementService.StopStream(result);
            check = _streamManagementService.DoesStreamExist(result);

            Assert.False(check);
        }
    }
}
