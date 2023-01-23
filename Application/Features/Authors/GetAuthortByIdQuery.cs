using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authors
{
    public class GetAuthortByIdQuery : IRequest<Response<Author>>
    {
        public int Id { get; set; }
        public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthortByIdQuery, Response<Author>>
        {
            private readonly IAuthorRepository _authorRepository;
            public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }
            public async Task<Response<Author>> Handle(GetAuthortByIdQuery query, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetByIdAsync(query.Id);
                if (author == null) throw new ApiException($"Author Not Found.");
                return new Response<Author>(author);
            }
        }
    }
}
