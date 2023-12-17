using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/{bookId:int}/comments")]
    public class CommentsController : ControllerBase
    {

    }
}