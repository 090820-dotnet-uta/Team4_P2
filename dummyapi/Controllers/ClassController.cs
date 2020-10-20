using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ClassController : ControllerBase
    {
        // GET: api/<ClassController>

        private readonly Repository _repository;

        public ClassController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Class>>> GetAll()
        {
            return await _repository.GetClasssAsync();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            return await _repository.GetClassAsync(id);
        }
        // GET api/<ClassController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClassController>
        [HttpPost]//Add
        public async Task<ActionResult<Class>> CreateClassAsync(int courseId, int teacherId,string location)
        {
            Class Class = new Class();
            Class.CourseID = courseId;
            Class.TeacherID = teacherId;
            Class.Location = location;
            try
            {
                var returnClass = await _repository.AddClass(Class);
                return returnClass;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]//update
        public async Task<ActionResult<Class>> PutClass(Class Class)
        {
            try
            {
                return await _repository.EditClassScoreAsync(Class);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteClass(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteClass(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
