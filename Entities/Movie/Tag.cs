namespace MoviesListApi.Entities.Movie
{
    public class Tag
    {
        public int Id { get; set; }
        public int MovieId { get; set; }    
        public string TagName { get; set; }
   
        public Movie Movie { get; set; }
    }
}
