using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFAssignment2.Application.Dtos;
using EFAssignment2.Application.Services;
using EFAssignment2.Application.Interfaces;
using EFAssignment2.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Initializes the UserController with the UserService.
        /// </summary>
        /// <param name="userService">The IUserService instance.</param>
        public UserController(IUserService userService,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new User record.
        /// </summary>
        /// <param name="userDto">The UserDto object to create.</param>
        /// <returns>The created UserDto object.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User
        ///
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser([FromBody] UserDto userDto)
        {
            try
            {
                var existingUsers = await _userService.GetAllUsersAsync();
                var existingUser = existingUsers.FirstOrDefault(u => u.Name == userDto.Name
                || u.EmailAddress == userDto.EmailAddress);

                if (existingUser == null)
                {
                    await _userService.CreateUserAsync(userDto);
                    return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
                }
                else
                {
                    return BadRequest("User exists already!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a specific User record by ID.
        /// </summary>
        /// <param name="id">The ID of the User record.</param>
        /// <returns>The requested UserDto record.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/User/{id}
        ///
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync((int)id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates a specific User record by ID.
        /// </summary>
        /// <param name="id">The ID of the User record to update.</param>
        /// <param name="userDto">The updated UserDto object.</param>
        /// <returns>No content on success.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/User/{id}
        ///
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userService.UpdateUserAsync(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        /// <summary>
        /// Checks if a User record exists by ID.
        /// </summary>
        /// <param name="id">The ID of the User record.</param>
        /// <returns>True if the User record exists, otherwise false.</returns>
        private async Task<bool> UserExists(long id)
        {
            var user = await _userService.GetUserByIdAsync((int)id);
            return user != null;
        }

        /// <summary>
        /// Test method for listing, adding, updating, and deleting users.
        /// </summary>
        /// <param name="userDto">The UserDto object to create.</param>
        /// <returns>The created UserDto object.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User/Test
        ///
        /// </remarks>
        [HttpPost("Test")]
        public async Task<ActionResult<UserDto>> Test()
        {
            try
            {
                await ListUsers();

                var userDto = new UserDto {
                     Name = "James",
                     EmailAddress = "james@email.com",
                     PhoneNumber = "333-555-5555"
                };
                await _userService.CreateUserAsync(userDto);
                _logger.LogInformation($"Added user: {userDto.Name}");

                await ListUsers();

                var list = await _userService.GetAllUsersAsync();
                var userDto2 = list.First();
                userDto2.Name = $"{userDto2.Name} Updated2";
                await _userService.UpdateUserAsync(userDto2);
                _logger.LogInformation($"Updated user: {userDto2.Name}");

                await ListUsers();

                var list2 = await _userService.GetAllUsersAsync();
                var userDto3 = list2.Last();
                await _userService.DeleteUserAsync(userDto3.Id);
                _logger.LogInformation($"Deleted user: {userDto.Id}");

                await ListUsers();

                return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during the test operations.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <returns>A list of users</returns>
        private async Task<IEnumerable<UserDto>> ListUsers()
        {
            var allUsers = await _userService.GetAllUsersAsync();
            _logger.LogInformation("All users:");
            foreach (var user in allUsers)
            {
                _logger.LogInformation($"{user.Id} - {user.Name} - {user.EmailAddress}");
            }

            return allUsers;
        }
    }
}
