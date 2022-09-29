using API.Context;
using API.Models;
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
    public class EmployeeController : ControllerBase
    {
        MyContext myContext;
        public EmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        //READALL
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Employees.ToList();
            return Ok(new { message = "sukses mengambil data karyawan", statusCode = 200, data = data });
        }

        //READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Employees.Find(id);
            if (data == null)
            {
                return Ok(new { message = "data doesnt exist", statusCode = 200, data = data });
            }
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }
        //CREATE
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            myContext.Employees.Add(employee);
            var data = myContext.SaveChanges();
            if (data == 0)
            {
                return BadRequest(new { message = "gagal menambahkan data", statusCode = 401 });
            }
            return Ok(new { message = "sukses menambahkan data", statusCode = 201 });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(Employee employee)
        {

            var check = myContext.Employees.Find(employee.Id);
            if (check == null)
            {
                return BadRequest(new { message = "gagal merubah data", statusCode = 400 });
            }
            myContext.Employees.Update(employee);
            myContext.SaveChanges();
            return Ok(new { message = "sukses menambahkan data", statusCode = 201 });
        }

        //DELETE
        [HttpDelete]
        public IActionResult Delete(Employee employee)
        {
            //BAD PRACTICE MAYBE ??
            try
            {
                myContext.Employees.Remove(employee);
                var check = myContext.SaveChanges();
                return Ok(new { message = "sukses menghapus data", statusCode = 200 });
            }
            catch
            {
                return BadRequest(new { message = "gagal menghapus data", statusCode = 400 });
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = myContext.Employees.Find(id);
                myContext.Employees.Remove(data);
                var check = myContext.SaveChanges();
                return Ok(new { message = "sukses menghapus data", statusCode = 200 });
            }
            catch
            {
                return BadRequest(new { message = "gagal menghapus data", statusCode = 400 });
            }

        }
    }
}
