﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamAPI.Models
{
    public class StreamModel
    {
        public Guid StreamId { get; set; }
        public Guid UserId { get; set; }
        public Guid VideoId { get; set; }
    }
}
