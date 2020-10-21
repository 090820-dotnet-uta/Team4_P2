using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team4_P2.Models;
using Team4_P2.Repo.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dummyapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>

        private readonly Repository _repository;

        public StudentController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            return await _repository.GetStudentsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            return await _repository.GetStudentAsync(id);
        }
        
        [HttpPost]//Add
        public async Task<ActionResult<Student>> CreateStudentAsync(Student student)
        {
            try
            {
                var returnStudent = await _repository.AddStudent(student);
                return returnStudent;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]//update
        public async Task<ActionResult<Student>> PutStudent(Student Student)
        {
            try
            {
                return await _repository.EditStudentScoreAsync(Student);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteStudent(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteStudent(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
