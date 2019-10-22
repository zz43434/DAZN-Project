using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using VideoStreamAPI.Services;
using VideoStreamAPI.Interfaces;

namespace VideoStreamTests
{
    public class AuthorizationServiceTest
    {
        private AuthorizationService _authorizationService = new AuthorizationService();

        [Fact]
        public void ReturnUserIsAuthorized_Fail()
        {
            var user = Guid.NewGuid();

            var auth = _authorizationService.IsUserAuthorized(user);

            Assert.False(auth.Result);
        }

        [Fact]
        public async void ReturnUserIsAuthorized_Pass()
        {
            var user = Guid.NewGuid();

            var auth = _authorizationService.IsUserAuthorized(user);

            Assert.False(auth.Result);

            await _authorizationService.AuthorizeUser(user);

            auth = _authorizationService.IsUserAuthorized(user);

            Assert.True(auth.Result);
        }
        
        [Fact]
        public async void AuthorizesUser_Pass()
        {
            var user = Guid.NewGuid();

            await _authorizationService.AuthorizeUser(user);

            var result = _authorizationService.IsUserAuthorized(user);

            Assert.True(result.Result);
        }

        [Fact]
        public async void AuthorizeUserWhoIsAlreadyAuthorized_Fail()
        {
            var user = Guid.NewGuid();

            await _authorizationService.AuthorizeUser(user);

            var result = await _authorizationService.AuthorizeUser(user);

            Assert.Equal("User already authorized", result);
        }

        [Fact]
        public async void UserFound_Pass()
        {
            var user = Guid.NewGuid();

            await _authorizationService.AuthorizeUser(user);

            var result = _authorizationService.DoesUserExist(user);

            Assert.True(result);
        }

        [Fact]
        public void UserNotFound_Pass()
        {
            var user = Guid.NewGuid();

            var result = _authorizationService.DoesUserExist(user);

            Assert.False(result);
        }
    }
}
