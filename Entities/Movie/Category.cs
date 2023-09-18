namespace MoviesListApi.Entities.Movie
{
    public class Category
    {
        public int Id { get; set; }
        public int PreferencesId { get; set; }
        public string CategoryName { get; set; }
        public Preferences Preferences { get; set; }
    }
}
