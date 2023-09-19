using MoviesListApi.Entities;

namespace MoviesListApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Movie> FavoritesMovies { get; set; }
        public Preferences Preferences { get; set; }
    }
}
