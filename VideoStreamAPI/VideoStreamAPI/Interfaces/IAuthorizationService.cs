﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Interfaces
{
    public interface IAuthorizationService
    {
        Task<bool> IsUserAuthorized(Guid clientId);

        Task<string> AuthorizeUser(Guid clientId);
        
        void SetClients();

        bool DoesUserExist(Guid clientId);
    }
}
