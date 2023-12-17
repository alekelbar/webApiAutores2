using System.ComponentModel.DataAnnotations;

namespace webApi.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<AuthorBooks> AuthorBooks { get; set; } = null!;
    }
}