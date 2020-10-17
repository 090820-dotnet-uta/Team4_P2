using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AssignmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AssignmentController>/5
        [HttpPut("{id}")]//update
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssignmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
