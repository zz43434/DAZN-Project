using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VideoStreamTests
{
    public class AuthorizationServiceTest
    {
        [Fact]
        public void ReturnUserIsAuthorized_Pass() { }

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
