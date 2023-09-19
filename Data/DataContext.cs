using Microsoft.EntityFrameworkCore;
using MoviesListApi.Entities;

namespace MoviesListApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<Metadata> Metadata { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
