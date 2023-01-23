using System.Threading.Tasks;
using Application.Features.Genries;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class GenriesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllGenriesParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllGenriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGenriesByIdQuery { Id = id }));
        }
    }
}
