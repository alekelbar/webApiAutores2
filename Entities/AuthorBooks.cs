using System.ComponentModel.DataAnnotations;

namespace webApi.Entities
{
    public class AuthorBooks
    {
        // TODO: Implementar las llave principal compuesta...
        [Key]
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        // propiedad de navegación para relación muchos a muchos...
        public Book Book { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}