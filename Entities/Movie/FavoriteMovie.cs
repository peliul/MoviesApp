﻿namespace MoviesListApi.Entities
{
    public class FavoriteMovie
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
