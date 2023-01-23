using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Genries
{
    public partial class CreateGenriesCommand : IRequest<Response<Genre>>
    {
        public string Name { get; set; }
    }
    public class CreateGenriesCommandHandler : IRequestHandler<CreateGenriesCommand, Response<Genre>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public CreateGenriesCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<Response<Genre>> Handle(CreateGenriesCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Genre>(request);
            await _genreRepository.AddAsync(genre);
            return new Response<Genre>(genre);
        }
    }
}
