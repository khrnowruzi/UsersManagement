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

        [HttpPost("GetUser/{userId}", Name = nameof(GetUser))]
        public async Task<IActionResult> GetUser(int? userId)
        {
            if (!userId.HasValue || userId < 0)
            {
                return BadRequest(new ErrorDTO
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid Id!"
                });
            }

            try
            {
                var user = await _userService.GetAsync(userId.Value);
                return Ok(_mapper.Map<User, UserDTO>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message
                });
            }

        }

        [HttpPost(nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromForm] UserDTO user)
        {
            user.Id = 0;
            var addedUser = await _userService.CreateAsync(_mapper.Map<UserDTO, User>(user));
            return Ok(_mapper.Map<User, UserDTO>(addedUser));
        }

        [HttpPut("EditUser/{userId}", Name = nameof(EditUser))]
        public async Task<IActionResult> EditUser(int? userId, [FromForm] UserDTO user)
        {
            if (!userId.HasValue || userId < 0)
            {
                return BadRequest(new ErrorDTO
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid Id!"
                });
            }

            try
            {
                var updatedUser = await _userService.UpdateAsync(_mapper.Map<UserDTO, User>(user));
                return Ok(_mapper.Map<User, UserDTO>(updatedUser));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpPost("DeleteUser/{userId}", Name = nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(int? userId)
        {
            if (!userId.HasValue || userId < 0)
            {
                return BadRequest(new ErrorDTO
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Invalid Id!"
                });
            }

            try
            {
                return Ok(await _userService.DeleteAsync(userId.Value));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorDTO
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
