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
    public class AssignmentController : ControllerBase
    {
        // GET: api/<AssignmentController>

        private readonly Repository _repository;

        public AssignmentController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Assignment>>> GetAll()
        {
            return await _repository.GetAssignmentsAsync();
        }

        // GET api/<AssignmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> Get(int id)
        {
            return await _repository.GetAssignmentAsync(id);
        }

        // POST api/<AssignmentController>
        [HttpPost]//Add
        public async Task<ActionResult<Assignment>> CreateAssignmentAsync(int enrollmentId, int? grade, string title)
        {
            Assignment assignment = new Assignment();
            assignment.EnrollmentID = enrollmentId;
            if(grade.HasValue)
            {
                assignment.Grade = grade;
            }
            assignment.Title = title;
            try
            {
                var returnassignment = await _repository.AddAssignment(assignment);
                return returnassignment;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<AssignmentController>/5
        public async Task<ActionResult<Assignment>> PutAssignment(Assignment Assignment)
        {
            try
            {
                return await _repository.EditAssignmentScoreAsync(Assignment);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<AssignmentController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAssignment(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteAssignment(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
