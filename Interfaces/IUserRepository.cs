using MoviesListApi.DTO;
using MoviesListApi.Entities;

namespace MoviesListApi.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(int id);
        Task<bool> UserExists(int id);
    }
}
