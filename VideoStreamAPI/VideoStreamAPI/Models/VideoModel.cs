using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class VideoModel
    {
        public Guid VideoId { get; set; }
        public string VideoName { get; set; }
        public int VideoLength { get; set; }
    }
}
