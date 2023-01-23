using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Books
{
    public class DeleteBooksByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteBooksByIdCommandHandler : IRequestHandler<DeleteBooksByIdCommand, Response<int>>
        {
            private readonly IBookRepository _bookRepository;
            public DeleteBooksByIdCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Response<int>> Handle(DeleteBooksByIdCommand command, CancellationToken cancellationToken)
            {
                var author = await _bookRepository.GetByIdAsync(command.Id);
                if (author == null) throw new ApiException($"Book Not Found.");
                await _bookRepository.DeleteAsync(author);

                return new Response<int>(author.Id);
            }
        }
    }
}
