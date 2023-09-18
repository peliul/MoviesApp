using MoviesListApi.Entities.Movie;

namespace MoviesListApi.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Movie.Movie> FavoritesMovies { get; set; }
        public Preferences Preferences { get; set; }
    }
}
