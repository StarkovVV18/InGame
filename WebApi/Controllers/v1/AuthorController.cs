using System.Threading.Tasks;
using Application.Features.Authors;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAuthorParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllAuthorsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAuthortByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateAuthorCommand command)
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
            return Ok(await Mediator.Send(new DeleteAuthorByIdCommand { Id = id }));
        }
    }
}
