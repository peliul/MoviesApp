namespace MoviesListApi.Entities
{
    public class Metadata
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Url { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public Movie Movie { get; set; }
    }
}
