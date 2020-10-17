using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        // GET api/<CourseController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourseAsync(string title)
        {
            Course course = new Course();
            course.Title = title;
            try
            {
                var returnCourse = await _repository.AddCourse(course);
                return returnCourse;
            }
            catch(SqlException e)
            {
                return NoContent();
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]//update
        public async Task<ActionResult<Course>> PutCourse(Course course)
        {
            try
            {
                return await _repository.EditCourseScoreAsync(course);
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
