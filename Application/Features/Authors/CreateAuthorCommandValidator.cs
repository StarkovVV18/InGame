using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.Features.Authors
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

        }
    }
}
