using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Books
{
    public partial class CreateBooksCommand : IRequest<Response<Book>>
    {
        public string Name { get; set; }

        public string YearEdition { get; set; }

        public int GenreId { get; set; }

        public int AuthorId { get; set; }

        public string Redaction { get; set; }
    }
    public class CreateBooksCommandHandler : IRequestHandler<CreateBooksCommand, Response<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public CreateBooksCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<Book>> Handle(CreateBooksCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookRepository.AddAsync(book);
            return new Response<Book>(book);
        }
    }
}
