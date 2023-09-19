using MoviesListApi.Entities;

namespace MoviesListApi.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<FavoriteMovieDto> FavoritesMovies { get; set; }
        public Preferences Preferences { get; set; }
    }
}
