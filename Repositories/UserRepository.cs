using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MoviesListApi.Data;
using MoviesListApi.DTO;
using MoviesListApi.Entities;
using MoviesListApi.Interfaces;

namespace MoviesListApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _context.Users
                .Include(u => u.FavoritesMovies)
                .Include(u => u.Preferences)
                .ThenInclude(p => p.FavoriteCategories)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return users;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }
    }
}
