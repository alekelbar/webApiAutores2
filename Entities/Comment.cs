using System.ComponentModel.DataAnnotations;

namespace webApi.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}