using API.Context;
using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class OrderRepository
    {
        MyContext myContext;

        public OrderRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int RequestStockOrder(RequestOrder order)
        {
            Order data = new Order
            {
                CustomerId = order.customer.Id,
                StockId = order.stockId,
                OrderStatus = 1  /*BELUM LUNAS*/

            };
            myContext.Orders.Add(data);
            int result = myContext.SaveChanges();
            if (result == 0)
            {
                return result;
            }

            return 1;
        } 

        public int ConfirmStockOrder(Order order)
        {
            var data = myContext.Orders.Find(order.Id);
            data.State.Id = 2; /*LUNAS*/
            myContext.Orders.Add(data);
            int result = myContext.SaveChanges();
            if (result == 0)
            {
                return result;
            }

            return 1;
        }
    }
}
