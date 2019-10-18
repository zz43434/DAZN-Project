using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Services
{
    public class AuthorizationService
    {
        public bool IsUserAuthorized(Guid clientId)
        {
            return true;
        }
    }
}
