using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamAPI.Models;

namespace VideoStreamAPI.Interfaces
{
    public interface IVideoService
    {
        Task<List<VideoModel>> GetVideos();
        
        Task<VideoModel> GetVideo(Guid videoId);
        
    }
}
