using Application.Features.Genries;
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

namespace Application.Features.Genries
{
    public class GetAllGenriesQuery : IRequest<PagedResponse<IEnumerable<GetAllGenriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllGenriesQueryHandler : IRequestHandler<GetAllGenriesQuery, PagedResponse<IEnumerable<GetAllGenriesViewModel>>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GetAllGenriesQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllGenriesViewModel>>> Handle(GetAllGenriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllGenriesParameter>(request);
            var genries = await _genreRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var genriesViewModel = _mapper.Map<IEnumerable<GetAllGenriesViewModel>>(genries);
            return new PagedResponse<IEnumerable<GetAllGenriesViewModel>>(genriesViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
