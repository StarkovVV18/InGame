using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authors
{
    public partial class CreateAuthorCommand : IRequest<Response<Author>>
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Response<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Response<Author>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);
            await _authorRepository.AddAsync(author);
            return new Response<Author>(author);
        }
    }
}
