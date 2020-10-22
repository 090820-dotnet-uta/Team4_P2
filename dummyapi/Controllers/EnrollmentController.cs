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
    public class EnrollmentController : ControllerBase
    {
        // GET: api/<EnrollmentController>

        private readonly Repository _repository;

        public EnrollmentController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Enrollment>>> GetAll()
        {
            return await _repository.GetEnrollmentsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> Get(int id)
        {
            return await _repository.GetEnrollmentAsync(id);
        }
        
        [HttpPost]//Add
        public async Task<ActionResult<Enrollment>> CreateEnrollmentAsync(Enrollment Enrollment)
        {
            try
            {
                var returnEnrollment = await _repository.AddEnrollment(Enrollment);
                return returnEnrollment;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<EnrollmentController>/5
        [HttpPut]//update
        public async Task<ActionResult<Enrollment>> PutEnrollment(Enrollment Enrollment)
        {
            try
            {
                return await _repository.EditEnrollmentScoreAsync(Enrollment);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<EnrollmentController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteEnrollment(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteEnrollment(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
