using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class CustomerRepository
    {
        MyContext myContext;
        public CustomerRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public List<User> Get()
        {
            var data = myContext.Users.ToList();
            return data;
        }

        public int Delete(int id)
        {
            var data = myContext.Users.Find(id);
            myContext.Users.Remove(data);
            var check = myContext.SaveChanges();
            return check;
        }

        public User Get(int id)
        {
            var data = myContext.Users.Find(id);
            return data;
        }

        public int Put(User user)
        {
            var data = myContext.Users.Find(user.Id);
            myContext.Users.Update(data);
            int check = myContext.SaveChanges();
            return check;
        }
    }
}
