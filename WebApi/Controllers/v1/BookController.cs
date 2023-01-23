using System.Threading.Tasks;
using Application.Features.Books;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BookController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllBooksParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllBooksQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetBooksByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBooksCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBooksCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBooksByIdCommand { Id = id }));
        }
    }
}
