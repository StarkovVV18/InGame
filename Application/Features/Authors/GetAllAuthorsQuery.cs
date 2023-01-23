using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Authors
{
    public class GetAllAuthorsQuery : IRequest<PagedResponse<IEnumerable<GetAllPAuthorViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, PagedResponse<IEnumerable<GetAllPAuthorViewModel>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPAuthorViewModel>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllAuthorParameter>(request);
            var authors = await _authorRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var authorsViewModel = _mapper.Map<IEnumerable<GetAllPAuthorViewModel>>(authors);
            return new PagedResponse<IEnumerable<GetAllPAuthorViewModel>>(authorsViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
