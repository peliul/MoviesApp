using MoviesListApi.DTO;

namespace MoviesListApi.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync();
        Task<IEnumerable<MovieDto>> GetMoviesByCategoryAsync(string category);
        Task<IEnumerable<MovieDto>> GetMoviesByTagAsync(string tag);
    }
}
