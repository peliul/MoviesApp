using MoviesListApi.Entities;

namespace MoviesListApi.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public ICollection<Tag> Tags { get; set; }

        //length in minutes
        public int Length { get; set; }
        public DateTime Released { get; set; }
        public DateTime DateAvailableUntil { get; set; }
        public ICollection<MetadataDto> Metadata { get; set; }
    }
}
