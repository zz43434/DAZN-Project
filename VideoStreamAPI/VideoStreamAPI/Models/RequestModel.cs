using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class RequestModel
    {
        public Guid UserId { get; set; }
        public Guid VideoId { get; set; }
    }
}
