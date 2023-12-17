using Microsoft.EntityFrameworkCore;
using webApi.Entities;

namespace webApi.Database
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relación de muchos a muchos, llave compuesta...
            modelBuilder.Entity<AuthorBooks>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBooks> AuthorBooks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}