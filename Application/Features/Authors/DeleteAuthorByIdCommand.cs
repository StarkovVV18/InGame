using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authors
{
    public class DeleteAuthorByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, Response<int>>
        {
            private readonly IAuthorRepository _authorRepository;
            public DeleteAuthorByIdCommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }
            public async Task<Response<int>> Handle(DeleteAuthorByIdCommand command, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetByIdAsync(command.Id);
                if (author == null) throw new ApiException($"Author Not Found.");
                await _authorRepository.DeleteAsync(author);

                return new Response<int>(author.Id);
            }
        }
    }
}
