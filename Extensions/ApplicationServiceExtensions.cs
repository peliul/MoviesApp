using Microsoft.EntityFrameworkCore;
using MoviesListApi.Data;
using MoviesListApi.Interfaces;
using MoviesListApi.Repositories;

namespace MoviesListApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
