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

        [HttpGet]
        public async Task<IActionResult> IsUserAuthorized(Guid clientId)
        {
            var authorized = await _authorizationService.IsUserAuthorized(clientId);

            if (authorized)
            {
                return Ok(authorized);
            }

            return Unauthorized();
        }

        [HttpGet("/authorize-user/{clientId}")]
        public async Task<ActionResult> AuthorizeUser(Guid clientId)
        {
            var result = await _authorizationService.AuthorizeUser(clientId);
            return Ok(result);
        }
    }
}
