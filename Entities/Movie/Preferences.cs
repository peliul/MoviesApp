﻿
namespace MoviesListApi.Entities
{
    public class Preferences
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<FavoriteCategory> FavoriteCategories { get; set; }
        public string Theme { get; set; }
        public User User { get; set; }
    }
}
