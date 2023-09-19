using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesListApi.Data;
using MoviesListApi.DTO;
using MoviesListApi.Entities;
using MoviesListApi.Interfaces;

namespace MoviesListApi.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MoviesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            var movies = await _context.Movies
                .Include(m => m.Metadata)
                .Include(m => m.Tags)
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByCategoryAsync(string category)
        {
            var movies = await _context.Movies
                .Where(m => m.Genre == category)
                .Include(m => m.Metadata)
                .Include(m => m.Tags)
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByTagAsync(string tag)
        {
            var movies = await _context.Movies
                .Where(m => m.Tags.Any(t => t.TagName == tag))
                .Include(m => m.Metadata)
                .Include(m => m.Tags)
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return movies;
        }
    }
}
