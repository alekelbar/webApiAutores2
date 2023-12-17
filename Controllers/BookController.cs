using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Se listan tareas");
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> GetById([FromRoute] int id)
        {
            return Ok("Se listan tareas");
        }

        [HttpPost]
        public ActionResult<string> Post()
        {
            return Ok("se crea un recurso");
        }

        [HttpPut("{id:int}")]
        public ActionResult<string> Put([FromRoute] int id)
        {
            return Ok("se actualiza un recurso");
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> Delete([FromRoute] int id)
        {
            return Ok("se elimina un recurso");
        }
    }
}