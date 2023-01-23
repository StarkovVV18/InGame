using Application.Features.Authors;
using Application.Features.Books;
using Application.Features.Genries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Author, GetAllPAuthorViewModel>().ReverseMap();
            CreateMap<CreateAuthorCommand, Author>().ReverseMap();
            CreateMap<GetAllAuthorsQuery, GetAllAuthorParameter>();

            CreateMap<CreateBooksCommand, Book>().ReverseMap();
            CreateMap<Book, GetAllBooksViewModel>().ReverseMap();
            CreateMap<GetAllBooksQuery, GetAllBooksParameter>();

            CreateMap<CreateGenriesCommand, Genre>().ReverseMap();
            CreateMap<Genre, GetAllGenriesViewModel>().ReverseMap();
            CreateMap<GetAllGenriesQuery, GetAllGenriesParameter>();
        }
    }
}
