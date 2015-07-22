using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using WebApi.Models;
using WebApi.Repositories.Contracts;

namespace WebApi.API
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        readonly IStudentRepository _studentRepository;  
        public StudentsController(IStudentRepository studentRepository)  
        {
            _studentRepository = studentRepository;
        }        
        
        // GET: api/students
        [HttpGet]
        public IEnumerable<Student> Get()
        {  
            try
            {
                var students = this._studentRepository.AllStudents();
                return students;
            }
            catch
            {                
                return null;
            }
               
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public Student Get(string id)
        {
            var student = this._studentRepository.GetById(id);
            return student;
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
        	if (!ModelState.IsValid)
        	{
        		Context.Response.StatusCode = 400;
                return new ObjectResult(new { Status = "Model invalido" });
        	}
        	else
        	{
                this._studentRepository.Add(student);
                Context.Response.StatusCode = 201;
                return new ObjectResult(student);        	   
        	}
        }

        // PUT api/students
        [HttpPut]
        public IActionResult Put([FromBody]Student student)
        {
            if (!ModelState.IsValid)
        	{
        		Context.Response.StatusCode = 400;                
                return new ObjectResult(new { Status = "Model invalido" });
        	}
        	else
        	{
                this._studentRepository.Update(student);
                Context.Response.StatusCode = 201;
                return new ObjectResult(student);        	   
        	}
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var status = this._studentRepository.Remove(id);
            return new ObjectResult(new { Status = status });
        }
    }
}
