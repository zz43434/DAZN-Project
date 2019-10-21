using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Interfaces
{
    public interface IStreamManagementService
    {

        Task<StreamModel> RequestStream(RequestModel request);
        
        Task CloseStream(Guid streamId);
        
        bool IsClientExceedingStreamLimit(Guid clientId);
        
        List<StreamModel> CurrentStreams(Guid clientId);
        
        bool DoesStreamExist(Guid clientId);
    }
}
