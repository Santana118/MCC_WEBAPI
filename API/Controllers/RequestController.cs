using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        OrderRepository orderRepository;
        public RequestController(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        [HttpPost]
        public IActionResult PostConsumerOrder(RequestOrder requestOrder)
        {
            int check = orderRepository.RequestStockOrder(requestOrder);
            if (check > 0)
            {
                return Ok(new { message = "sukses input data order", statusCode = 201 });
            }

            return BadRequest(new { message = "gagal memasukkan data order", statusCode = 401 });
        }

        [HttpPut]
        public IActionResult PutAcceptedOrder(Order order)
        {
            int check = orderRepository.ConfirmStockOrder(order);
            if (check > 0)
            {
                return Ok(new { message = "sukses update data order", statusCode = 201 });
            }

            return BadRequest(new { message = "gagal update data", statusCode = 401 });
        }

    }
}
