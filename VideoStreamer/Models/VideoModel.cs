using System;
namespace VideoStreamer.Models
{
    public class VideoModel
    {
        public Guid VideoId { get; set; }
        public string VideoName { get; set; }
        public int Length { get; set; }
    }
}
