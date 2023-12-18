using webApi.Entities;

namespace webApi.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<AuthorBooks> AuthorBooks { get; set; } = null!;
    }
}