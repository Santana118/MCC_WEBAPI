using API.Context;
using API.Models;
using API.Repositories.Data;
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
    public class DivisionController : ControllerBase
    {
        DivisionRepository divisionRepository;
        public DivisionController(DivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }
        //READALL
        [HttpGet]
        public IActionResult Get()
        {
            var data = divisionRepository.Get();
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data});
        }

        //READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = divisionRepository.Get(id);
            if (data == null)
            {
                return Ok(new { message = "data doesnt exist", statusCode = 200, data = data });
            }
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }
        //CREATE
        [HttpPost]
        public IActionResult Post(Division division)
        {
            var data = divisionRepository.Post(division);
            if (data == 0)
            {
                return BadRequest(new { message = "gagal menambahkan data", statusCode = 401 });
            }
            return Ok(new { message = "sukses menambahkan data", statusCode = 201 });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(Division division)
        {
            int check = divisionRepository.Put(division);
            if (check == 0)
            {
                return BadRequest(new { message = "gagal merubah data", statusCode = 400 });
            }
            
            return Ok(new { message = "sukses menambahkan data", statusCode = 201 });

        }



        //DELETE
        //[HttpDelete]
        //public IActionResult Delete(Division division)
        //{
            
        //    try
        //    {
        //        myContext.Divisions.Remove(division);
        //        var check = myContext.SaveChanges();
        //        return Ok(new { message = "sukses menghapus data", statusCode = 200 });
        //    }
        //    catch
        //    {
        //        return BadRequest(new { message = "gagal menghapus data", statusCode = 400 });
        //    }
            
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var check = divisionRepository.Delete(id);
            if (check > 0)
            {
                return Ok(new { message = "sukses menghapus data", statusCode = 200 });
            }
            return BadRequest(new { message = "gagal menghapus data", statusCode = 400 });
        }
    }
}
