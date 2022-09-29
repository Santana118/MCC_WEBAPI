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
    public class RoleController : ControllerBase
    {
        MyContext myContext;
        public RoleController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Roles.ToList();
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //GETBYID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Roles.Find(id);
            if (data == null)
            {
                return Ok(new { message = "data doesnt exist", statusCode = 200, data = data });
            }
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Role role)
        {
            myContext.Roles.Add(role);
            var data = myContext.SaveChanges();
            if (data == 0)
            {
                return BadRequest(new { message = "gagal menambahkan data", statusCode = 401 });
            }
            return Ok(new { message = "sukses menambahkan data", statusCode = 201 });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(Role role)
        {
            var check = myContext.Roles.Find(role.Id);
            if (check == null)
            {
                return BadRequest(new { message = "gagal merubah data", statusCode = 400 });
            }
            myContext.Roles.Update(role);
            myContext.SaveChanges();
            return Ok(new { message = "sukses menambahkan data", statusCode = 201 });
        }

        //DELETE
        [HttpDelete]
        public IActionResult Delete(Role role)
        {
            //OBV THIS IS BAD PRACTICE 
            try
            {
                myContext.Roles.Remove(role);
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
