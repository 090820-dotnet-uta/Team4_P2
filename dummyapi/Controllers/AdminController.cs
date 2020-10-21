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
    public class AdminController : ControllerBase
    {
        // GET: api/<AdminController>

        private readonly Repository _repository;

        public AdminController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Admin>>> GetAll()
        {
            return await _repository.GetAdminsAsync();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> Get(int id)
        {
            return await _repository.GetAdminAsync(id);
        }

        // POST api/<AdminController>
        [HttpPost]//Add
        public async Task<ActionResult<Admin>> CreateAdminAsync(Admin Admin)
        {
            try
            {
                var returnAdmin = await _repository.AddAdmin(Admin);
                return returnAdmin;
            }
            catch
            {
                return NoContent();
            }
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Admin>> PutAdmin(Admin Admin)
        {
            try
            {
                return await _repository.EditAdminScoreAsync(Admin);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }
        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAdmin(int id)
        {
            Boolean result;
            try
            {
                result = await _repository.DeleteAdmin(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            return result;
        }
    }
}
