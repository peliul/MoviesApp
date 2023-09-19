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
        public DbSet<FavoriteMovie> FavoriteMovies { get;set; }
        public DbSet<FavoriteCategory> FavoriteCategories { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FavoriteMovie>()
                 .HasKey(k => new { k.UserId, k.MovieId });

            modelBuilder.Entity<FavoriteMovie>()
                .HasOne(u => u.User)
                .WithMany(m => m.FavoritesMovies)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteCategory>()
                .HasKey(k => new { k.CategoryId, k.PreferencesId });

            modelBuilder.Entity<FavoriteCategory>()
                .HasOne(p => p.Preferences)
                .WithMany(c => c.FavoriteCategories)
                .HasForeignKey(k => k.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
