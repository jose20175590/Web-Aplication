using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController (IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _studentService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Students model)
        {
            return Ok(_studentService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Students model)
        {
            return Ok( _studentService.Add(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok( _studentService.Delete(id));
        }
    }
}
