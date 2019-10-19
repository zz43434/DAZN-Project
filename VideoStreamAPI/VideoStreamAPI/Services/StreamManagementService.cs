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

        public bool IsClientExceedingStreamLimit(RequestModel request)
        {
            return true;
        }

        public void UserWatchCount(RequestModel request)
        {
            var clientStreams = streams.FindAll(a => a.ClientId == request.ClientId && a.EndedWatching == null);

            if (clientStreams.Count > 3)
            {
                streams.Add(new StreamingDetailsModel
                {
                    ClientId = request.ClientId,
                    VideoId = request.VideoId,
                    StartedWatching = DateTime.Now,
                    EndedWatching = null
                });

                _logger.Debug(@"User is currently watching {clientStreams} videos");
            }
            else
            {
                _logger.Debug("User is exceeding stream limit");
            }
        }

        public void UserStoppedWatching(RequestModel request)
        {
            var stream = streams.Find(a => a.ClientId == request.ClientId && a.VideoId == request.VideoId && a.EndedWatching == null);

            stream.EndedWatching = DateTime.Now;
            
        }

        readonly List<StreamingDetailsModel> streams = new List<StreamingDetailsModel>()
        {
            new StreamingDetailsModel
            {
                ClientId = Guid.Parse("54d6e703-23e4-453b-9ede-0dc4cdfa7174"),
                VideoId = Guid.Parse("b1ce21b0-d542-4631-a662-cde3db788f73"),
                StartedWatching = DateTime.Now,
                EndedWatching = null
            },
            new StreamingDetailsModel
            {
                ClientId = Guid.Parse("b5b4f338-3703-4323-a379-bb067afcb4fd"),
                VideoId = Guid.Parse("b1ce21b0-d542-4631-a662-cde3db788f73"),
                StartedWatching = DateTime.Now,
                EndedWatching = null
            },
            new StreamingDetailsModel
            {
                ClientId = Guid.Parse("852c619e-ff88-4597-8966-be180fa345d9"),
                VideoId = Guid.Parse("b1ce21b0-d542-4631-a662-cde3db788f73"),
                StartedWatching = DateTime.Now,
                EndedWatching = null
            },
            new StreamingDetailsModel
            {
                ClientId = Guid.Parse("852c619e-ff88-4597-8966-be180fa345d9"),
                VideoId = Guid.Parse("b1ce21b0-d542-4631-a662-cde3db788f73"),
                StartedWatching = DateTime.Now,
                EndedWatching = null
            },
        };
    }
}
