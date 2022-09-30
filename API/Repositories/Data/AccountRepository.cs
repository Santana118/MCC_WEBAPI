using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {

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
                    x.User.Employee.Email.Equals(login.Email));
            if (data == null)
            {
                return null;
            }
            bool check = Hashing.PasswordVerify(login.Password, data.User.Password);
            if (check == true)
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

        public int Register(RegisterAccount registerAccount)
        {
            Employee employeeData = new Employee
            {
                //Id = registerAccount.Id,
                FullName = registerAccount.FullName,
                Email = registerAccount.Email

            };
            myContext.Employees.Add(employeeData);
            int result = myContext.SaveChanges();
            if (result == 0)
            {
                return result;
            }

            User userData = new User
            {
                Id = employeeData.Id,
                Password = Hashing.PasswordHashing(registerAccount.Password),
                Employee = employeeData

            };
            myContext.Users.Add(userData);
            result = myContext.SaveChanges();
            if (result == 0)
            {
                return result;
            }

            UserRole userroleData = new UserRole
            {
                UserId = employeeData.Id,
                RoleId = registerAccount.Role

            };
            myContext.UserRoles.Add(userroleData);
            result = myContext.SaveChanges();
            if (result == 0)
            {
                return result;
            }
            return result;
        }

        public int ChangePassword(ChangePassword changePassword)
        {


            //var data = myContext.UserRoles
            //        .Include(x => x.Role)
            //        .Include(x => x.User)
            //        .Include(x => x.User.Employee)
            //        .FirstOrDefault(x =>
            //            x.User.Employee.Email.Equals(changePassword.login.Email) &&
            //            x.User.Password.Equals(PasswordHashing(changePassword.login.Password)));

            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x =>
                    x.User.Employee.Email.Equals(changePassword.login.Email));
            
            if (data == null)
            {
                return 0;
            }
            bool check = Hashing.PasswordVerify(changePassword.login.Password, data.User.Password);
            if (check == false)
            {
                return 0;
            }
            User dataUser = myContext.Users.Find(data.UserId);
            dataUser.Password = Hashing.PasswordHashing(changePassword.newPassword);
            myContext.Users.Update(dataUser);
            int result = myContext.SaveChanges();
            if (result == 0)
            {
                return result;
            }
            return 1;
        }

        

    }
}
