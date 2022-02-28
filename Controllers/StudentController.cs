using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CoolApi.Models;
using System;
using CoolApi.Services;

namespace CoolApi.Controllers
{
    [Route("api/[controller]")]

    //Web api
    //https://localhost:5001/api/student
    [ApiController]
    public class StudentController :Controller
    {
    
        private IStudentService _studentService;
        
        public StudentController(IStudentService context)
        {
            _studentService = context;
        }

        [HttpGet]
         public IActionResult GetAll()
         {
                List<Student> s1  = _studentService.GetAllData();
                return Ok(s1);
          }

    }
}