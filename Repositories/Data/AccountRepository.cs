using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        //LOGIN
        //REGISTER
        //CHANGE PASSWD
        //FORGET PASSWORD


        //Requirement Login : email + password
        //response Login : Id karyawan,  fullname, email, role (JWT TOKEN / JSON web Token)
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public ResponseLogin Login(Login login)
        {
            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x =>
                    x.User.Employee.Email.Equals(login.Email) &&
                    x.User.Password.Equals(login.Password));
            if (data != null)
            {
                ResponseLogin responseLogin = new ResponseLogin()
                {
                    Id = data.UserId,
                    FullName = data.User.Employee.FullName,
                    Email = data.User.Employee.Email,
                    Role = data.Role.Name

                };
                return responseLogin;
                
            }
            return null;
        }

    }
}
