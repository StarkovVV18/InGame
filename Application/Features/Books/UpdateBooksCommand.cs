using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Books
{
    public class UpdateBooksCommand : IRequest<Response<Book>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string YearEdition { get; set; }

        public int GenreId { get; set; }

        public int AuthorId { get; set; }

        public string Redaction { get; set; }

        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateBooksCommand, Response<Book>>
        {
            private readonly IBookRepository _bookRepository;
            public UpdateAuthorCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Response<Book>> Handle(UpdateBooksCommand command, CancellationToken cancellationToken)
            {
                var book = await _bookRepository.GetByIdAsync(command.Id);

                if (book == null)
                {
                    throw new ApiException($"Book Not Found.");
                }
                else
                {
                    book.Name = command.Name;

                    await _bookRepository.UpdateAsync(book);
                    return new Response<Book>(book);
                }
            }
        }
    }
}
