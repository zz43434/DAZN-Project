using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string ClientName { get; set; }
    }
}
