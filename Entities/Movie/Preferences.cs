using MoviesListApi.Entities.User;

namespace MoviesListApi.Entities.Movie
{
    public class Preferences
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<Category> FavoriteCategories { get; set; }
        public string Theme { get; set; }
        public User.User User { get; set; }
    }
}
