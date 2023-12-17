
using System.ComponentModel.DataAnnotations;

namespace webApi.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public List<AuthorBooks> AuthorBooks { get; set; } = null!;
        public List<Comment> Comments { get; set; } = null!;
    }
}