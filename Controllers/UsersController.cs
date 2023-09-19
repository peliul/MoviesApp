using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesListApi.Data;
using MoviesListApi.DTO;
using MoviesListApi.Entities;
using MoviesListApi.Interfaces;

namespace MoviesListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id) 
        {
            if (!await _userRepository.UserExists(id))
            {
                return BadRequest("User doesn't exist!");
            }

            var user = await _userRepository.GetUserAsync(id);

            return Ok(user);
        }

       
    }
}
