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
    public class CourseController : ControllerBase
    {
        // GET: api/<CourseController>

        private readonly Repository _repository;

        public CourseController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Course>>> GetAll()
        {
            return await _repository.GetCoursesAsync();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            return await _repository.GetCourseAsync(id);
        }
        
        [HttpPost]//Add
        public async Task<ActionResult<Course>> CreateCourseAsync(string title)
        {
            Course Course = new Course();
            Course.Title = title;
            try
            {
                var returnCourse = await _repository.AddCourse(Course);
                return returnCourse;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]//update
        public async Task<ActionResult<Course>> PutCourse(Course Course)
        {
            try
            {
                return await _repository.EditCourseScoreAsync(Course);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCourse(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteCourse(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
