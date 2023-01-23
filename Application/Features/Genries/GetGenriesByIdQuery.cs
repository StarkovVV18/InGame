using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Genries
{
    public class GetGenriesByIdQuery : IRequest<Response<Genre>>
    {
        public int Id { get; set; }
        public class GetGenriesByIdQueryHandler : IRequestHandler<GetGenriesByIdQuery, Response<Genre>>
        {
            private readonly IGenreRepository _genreRepository;
            public GetGenriesByIdQueryHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }
            public async Task<Response<Genre>> Handle(GetGenriesByIdQuery query, CancellationToken cancellationToken)
            {
                var book = await _genreRepository.GetByIdAsync(query.Id);
                if (book == null) throw new ApiException($"Genre Not Found.");
                return new Response<Genre>(book);
            }
        }
    }
}
