using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesListApi.Data;
using MoviesListApi.Entities;

namespace MoviesListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.Include(u => u.FavoritesMovies).Include(u => u.Preferences).ThenInclude(p => p.FavoriteCategories).ToList();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id) 
        {
            var user = _context.Users.Find(id);

            return user;
        }
    }
}
