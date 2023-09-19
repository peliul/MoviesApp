using AutoMapper;
using MoviesListApi.DTO;
using MoviesListApi.Entities;

namespace MoviesListApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<User, UserDto>();
            CreateMap<FavoriteMovie, FavoriteMovieDto>();
        }
    }
}
