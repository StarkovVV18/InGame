using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.Features.Books
{
    public class CreateBooksCommandValidator : AbstractValidator<CreateBooksCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBooksCommandValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
