using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team4_P2.Models;
using Team4_P2.Models.Models;
using Team4_P2.Repo.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dummyapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>

        private readonly Repository _repository;

        public UserController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await _repository.GetUsersAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _repository.GetUserAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]//Add
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            try
            {
                var returnUser = await _repository.AddUser(user);
                return returnUser;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<UserController>/5
        public async Task<ActionResult<User>> PutUser(User User)
        {
            try
            {
                return await _repository.EditUserScoreAsync(User);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteUser(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
