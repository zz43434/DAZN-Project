﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Interfaces
{
    public interface IStreamManagementService
    {
        bool IsClientExceedingStreamLimit(Guid clientId);

        Guid StartStream(Guid clientId);
        
        void StopStream(Guid streamId);
        
        List<StreamModel> CurrentStreams(Guid clientId);

        bool DoesStreamExist(Guid clientId);
    }
}
