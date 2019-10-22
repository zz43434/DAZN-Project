using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamAPI.Interfaces;
using VideoStreamAPI.Services;

namespace VideoStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private IAuthorizationService _authorizationService;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet("/{userId}")]
        public async Task<IActionResult> IsUserAuthorized(Guid userId)
        {
            var result = await _authorizationService.IsUserAuthorized(userId);

            if (result)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

        [HttpPost("/{userId/authorize")]
        public async Task<ActionResult> AuthorizeUser(Guid clientId)
        {
            var result = await _authorizationService.AuthorizeUser(clientId);
            return Ok(result);
        }
    }
}
