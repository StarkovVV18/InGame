using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Genries
{
    public class UpdateGenriesCommand : IRequest<Response<Genre>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateGenriesCommand, Response<Genre>>
        {
            private readonly IGenreRepository _genreRepository;
            public UpdateAuthorCommandHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }
            public async Task<Response<Genre>> Handle(UpdateGenriesCommand command, CancellationToken cancellationToken)
            {
                var genre = await _genreRepository.GetByIdAsync(command.Id);

                if (genre == null)
                {
                    throw new ApiException($"Genre Not Found.");
                }
                else
                {
                    genre.Name = command.Name;

                    await _genreRepository.UpdateAsync(genre);
                    return new Response<Genre>(genre);
                }
            }
        }
    }
}
