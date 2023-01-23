using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Genries
{
    public class DeleteGenriesByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteGenriesByIdCommandHandler : IRequestHandler<DeleteGenriesByIdCommand, Response<int>>
        {
            private readonly IGenreRepository _genreRepository;
            public DeleteGenriesByIdCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }
            public async Task<Response<int>> Handle(DeleteGenriesByIdCommand command, CancellationToken cancellationToken)
            {
                var author = await _genreRepository.GetByIdAsync(command.Id);
                if (author == null) throw new ApiException($"Genre Not Found.");
                await _genreRepository.DeleteAsync(author);

                return new Response<int>(author.Id);
            }
        }
    }
}
