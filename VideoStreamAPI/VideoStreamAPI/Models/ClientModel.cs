using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class ClientModel
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public int CurrentStreams { get; set; }
    }
}
