using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class RequestOrder
    {
        public Employee customer { get; set; }
        public int stockId { get; set; }
        public int quantity { get; set; }

    }
}
