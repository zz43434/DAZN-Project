using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class RequestModel
    {
        public Guid ClientId { get; set; }
        public Guid VideoId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
