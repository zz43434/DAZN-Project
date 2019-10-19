using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class StreamingDetailsModel
    {
        public Guid ClientId { get; set; }
        public Guid VideoId { get; set; }
        public DateTime StartedWatching { get; set; }
        public DateTime? EndedWatching { get; set; }
    }
}
