﻿using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Services
{
    public class AuthorizationService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public bool IsUserAuthorized(Guid clientId)
        {
            SetClients();

            if (DoesUserExist(clientId))
            {
                return true;
            }

            return false;
        }

        public List<Guid> Clients = new List<Guid>();

        public List<Tuple<Guid, bool>> Tokens = new List<Tuple<Guid, bool>>();

        public void SetClients()
        {
            Clients.Add(Guid.Parse("54d6e703-23e4-453b-9ede-0dc4cdfa7174"));
            Clients.Add(Guid.Parse("b5b4f338-3703-4323-a379-bb067afcb4fd"));
            Clients.Add(Guid.Parse("39ccb57c-811b-4e7d-83d8-217a3ad4fcba"));
        }

        public bool DoesUserExist(Guid clientId)
        {
            if (Clients.Contains(clientId))
            {
                return true;
            }
            return false;
        }


    }
}
