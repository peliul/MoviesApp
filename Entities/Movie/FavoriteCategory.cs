namespace MoviesListApi.Entities
{
    public class FavoriteCategory
    {
        public int CategoryId { get; set; }
        public int PreferencesId { get; set; }
        public Category Category { get; set; }
        public Preferences Preferences { get; set; }
    }
}
