using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Services
{
    public class StreamManagementService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private int maxStreams = 3;

        private List<StreamModel> streams = new List<StreamModel>();

        public bool IsClientExceedingStreamLimit(Guid clientId)
        {
            var streamCount = streams.Count(a => a.ClientId == clientId);

            if (streamCount > maxStreams)
            {
                return false;
            }

            return true;
        }

        public void StartStream(Guid clientId)
        {
            var newStream = new StreamModel
            {
                ClientId = clientId,
                StreamId = Guid.NewGuid()
            };

            streams.Add(newStream);

            _logger.Debug($"New stream added for client: {clientId}");
        }

        public List<StreamModel> CurrentStreams(Guid clientId)
        {
            var clientStreams = streams.FindAll(a => a.ClientId == clientId);

            return clientStreams;
        }

        public void StopStream(Guid streamId)
        {
            var stream = streams.Find(a => a.StreamId == streamId);

            streams.Remove(stream);            
        }
    }
}
