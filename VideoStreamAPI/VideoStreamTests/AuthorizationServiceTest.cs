using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using VideoStreamAPI.Services;

namespace VideoStreamTests
{
    public class AuthorizationServiceTest
    {
        public AuthorizationServiceTest()
        {
        }

        [Fact]
        public void ReturnUserIsAuthorized_Pass()
        {
        }

        [Fact]
        public void ReturnUserIsNotAuthorized_Pass() { }

        [Fact]
        public void AuthorizesUser_Pass() { }

        [Fact]
        public void AuthorizeUser_Fail() { }

        [Fact]
        public void UserNotFoundError_Pass() { }
    }
}
