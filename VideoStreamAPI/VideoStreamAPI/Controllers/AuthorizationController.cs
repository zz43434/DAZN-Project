﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamAPI.Services;

namespace VideoStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private AuthorizationService _authorizationService;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public AuthorizationController(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public ActionResult<bool> IsUserAuthorized(Guid clientId)
        {
            return _authorizationService.IsUserAuthorized(clientId);
        }

        [HttpGet("/authorize-user/{clientId}")]
        public string AuthorizeUser(Guid clientId)
        {
            
            return "User Authorized";
        }
    }
}
