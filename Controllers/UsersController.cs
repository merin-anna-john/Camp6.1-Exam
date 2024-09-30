using AssetManagementSystem_WebApi_MidExam.Models;
using AssetManagementSystem_WebApi_MidExam.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem_WebApi_MidExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Call repository
        private readonly IUserRepository _repository;

        // Dependency Injection
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        #region 1. Get All Users - Search All
        [HttpGet("getusers")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<IEnumerable<Login>>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }
        #endregion

        #region 2. Get User By ID
        [HttpGet("getuser/{id}")]
        public async Task<ActionResult<Login>> GetUserById(int id)
        {
            var user = await _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }
        #endregion

        #region 3. Insert User - Return Record
        [HttpPost("insertuser")]
        public async Task<ActionResult<Login>> InsertUser(UserRegistration userRegistration)
        {
            if (userRegistration == null)
            {
                return BadRequest("Invalid user registration data.");
            }

            var login = await _repository.InsertUserReturnRecord(userRegistration);
            if (login == null)
            {
                return StatusCode(500, "Error creating user.");
            }

            // Return the newly created user record with a 201 Created status
            return CreatedAtAction(nameof(GetUserById), new { id = login.LId }, login);
        }
        #endregion

        #region 4. Update User - Return Record
        [HttpPut("updateuser/{id}")]
        public async Task<ActionResult<Login>> UpdateUser(int id, UserRegistration userRegistration)
        {
            if (userRegistration == null || id <= 0)
            {
                return BadRequest("Invalid data provided.");
            }

            var updatedLogin = await _repository.UpdatUserReturnRecord(id, userRegistration);
            if (updatedLogin == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(updatedLogin); // Return updated user information
        }
        #endregion
    }
}
