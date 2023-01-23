using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Books
{
    public class GetBooksByIdQuery : IRequest<Response<Book>>
    {
        public int Id { get; set; }
        public class GetBooksByIdQueryHandler : IRequestHandler<GetBooksByIdQuery, Response<Book>>
        {
            private readonly IBookRepository _bookRepository;
            public GetBooksByIdQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Response<Book>> Handle(GetBooksByIdQuery query, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(query.Id);
                if (book == null) throw new ApiException($"Book Not Found.");
                return new Response<Book>(book);
            }
        }
    }
}
