using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Database;
using webApi.DTO;
using webApi.Entities;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController(ApplicationDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly ApplicationDbContext context = context;
        private readonly IMapper mapper = mapper;

        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] CreateAuthorDTO createAuthorDTO)
        {
            var author = mapper.Map<Author>(createAuthorDTO);

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            return Ok("Author created successfully");
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> ListAll()
        {
            var authors = await context.Authors.Include(a => a.AuthorBooks).ToListAsync();
            return mapper.Map<List<AuthorDTO>>(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuthorDTO>> GetOneById([FromRoute] int id)
        {
            var author = await context.Authors
                .Where(au => au.Id == id)
                .Include(a => a.AuthorBooks)
                .FirstOrDefaultAsync();

            if (author == null) return NotFound("Author not found");

            return mapper.Map<AuthorDTO>(author);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAuthor([FromBody] UpdateAuthorDTO authorDTO,
            [FromRoute] int id)
        {
            if (id != authorDTO.Id) return BadRequest("AuthorDTO.Id should be equal to Route.id");

            var authorExists = await context.Authors.AnyAsync(au => au.Id == id);
            if (!authorExists) return NotFound("Author not found");

            var author = mapper.Map<Author>(authorDTO);
            context.Authors.Update(author);

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> RemoveAuthor([FromRoute] int id)
        {
            // TODO: Eliminar todos los recursos relacionados con el autor...
            // Regla de negocio, si el autor no esta registrado, sus libros no
            // pueden estarlo...
            var author = await context.Authors
                .Include(au => au.AuthorBooks)
                .ThenInclude(ab => ab.Book)
                .FirstOrDefaultAsync(au => au.Id == id);

            if (author == null) return NotFound("Author not found");

            // filtro una lista con los libros asociados a este autor...
            var books = author.AuthorBooks.Select(ab => ab.Book).ToList();
            // elimino los recursos asociados ...
            // Eliminar las relaciones en la tabla intermedia
            context.AuthorBooks.RemoveRange(author.AuthorBooks);

            // eliminar los libros asociados a este autor
            context.Books.RemoveRange(books);

            // Finalmente, eliminar el autor...
            context.Authors.Remove(author);

            // Persistir los cambios
            await context.SaveChangesAsync();

            return Ok("author removed successfully");
        }
    }
}