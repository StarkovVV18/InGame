using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authors
{
    public class UpdateAuthorCommand : IRequest<Response<Author>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Response<Author>>
        {
            private readonly IAuthorRepository _authorRepository;
            public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }
            public async Task<Response<Author>> Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetByIdAsync(command.Id);

                if (author == null)
                {
                    throw new ApiException($"Author Not Found.");
                }
                else
                {
                    author.Name = command.Name;
                    author.Birthdate = command.Birthdate;

                    await _authorRepository.UpdateAsync(author);
                    return new Response<Author>(author);
                }
            }
        }
    }
}
