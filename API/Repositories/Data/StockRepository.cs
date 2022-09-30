using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class StockRepository 
    {
        MyContext myContext;
        public StockRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Stocks.Find(id);
            myContext.Stocks.Remove(data);
            var check = myContext.SaveChanges();
            return check;
        }

        public List<Stock> Get()
        {
            var data = myContext.Stocks.ToList();
            return data;
        }

        public Stock Get(int id)
        {
            var data = myContext.Stocks.Find(id);
            return data;
        }

        public int Post(Stock stock)
        {
            myContext.Stocks.Add(stock);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Put(Stock stock)
        {
            var data = myContext.Stocks.Find(stock.Id);
            myContext.Stocks.Update(data);
            int check = myContext.SaveChanges();
            return check;
        }
    }
}
