using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Application.Services;
using UsersManagement.Core.Entities;
using UsersManagement.WebAPI.Dtos;

namespace UsersManagement.WebAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpGet(nameof(GetAllUsers))]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _userService.GetAllAsync()));
        }

        [HttpGet($"{nameof(GetUser)}/userId")]
        public async Task<IActionResult> GetUser(int? userId)
        {
            if (userId == null || userId < 0)
            {
                return Status400BadRequest("Invalid Id!");
            }

            var user = await _userService.GetAsync(userId.Value);

            if (user == null)
            {
                return Status400BadRequest("User not found!");
            }

            return Ok(_mapper.Map<User, UserDTO>(user));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] UserDTO user)
        {
            return Ok(await _userService.CreateAsync(_mapper.Map<UserDTO, User>(user)));
        }

        [HttpPost]
        public async Task<IActionResult> EditUser([FromForm] UserDTO user)
        {
            return Ok(await _userService.UpdateAsync(_mapper.Map<UserDTO, User>(user)));
        }

        [HttpPost($"{nameof(DeleteUser)}/userId")]
        public async Task<IActionResult> DeleteUser(int? userId)
        {
            if (userId == null || userId < 0)
            {
                return Status400BadRequest("Invalid Id!");
            }

            return Ok(await _userService.DeleteAsync(userId.Value));
        }

        //Helper methods
        public BadRequestObjectResult Status400BadRequest(string message)
        {
            return BadRequest(new ErrorDTO
            {
                StatusCode = StatusCodes.Status400BadRequest,
                ErrorMessage = message
            });
        }
    }
}
