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
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>

        private readonly Repository _repository;

        public TeacherController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Teacher>>> GetAll()
        {
            return await _repository.GetTeachersAsync();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            return await _repository.GetTeacherAsync(id);
        }
        
        [HttpPost]//Add
        public async Task<ActionResult<Teacher>> CreateTeacherAsync(string firstName,string lastName,char gender)
        {
            Teacher Teacher = new Teacher();
            Teacher.FirstName = firstName;
            Teacher.LastName = lastName;
            Teacher.Gender = gender;
            try
            {
                var returnTeacher = await _repository.AddTeacher(Teacher);
                return returnTeacher;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]//update
        public async Task<ActionResult<Teacher>> PutTeacher(Teacher Teacher)
        {
            try
            {
                return await _repository.EditTeacherScoreAsync(Teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteTeacher(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteTeacher(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
