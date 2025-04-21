using Microsoft.AspNetCore.Mvc;
using SkyMirror.BusinessLogic.Dto.User;
using SkyMirror.BusinessLogic.Interfaces;

namespace SkyMirror.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                if (users == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while retrieving users.");

                if (!users.Any())
                    return NoContent();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound($"User with ID {id} not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving user: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(CreateUserRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = await _userService.RegisterUserAsync(request);
                return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating user: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound($"User with ID {id} not found.");

                await _userService.UpdateUserAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating user: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound($"User with ID {id} not found.");

                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting user: {ex.Message}");
            }
        }
    }
}
