﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.ViewModel
{
    public class ResponseClient
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public ResponseLogin data { get; set; }
        
    }
}
