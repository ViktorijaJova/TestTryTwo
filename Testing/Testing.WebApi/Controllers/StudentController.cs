using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.DataModels;
using Testing.Services.Services;

namespace Testing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentControler(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Student student1)
        {
            try
            {
                _studentService.Register(student1);
                return Ok("Successfully registered student congrats!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Student exception: {ex.Message}");
            }


        }


    }

}