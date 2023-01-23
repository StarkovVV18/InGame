using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Application.Features.Books
{
    public class GetAllBooksViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string YearEdition { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public string Redaction { get; set; }
    }
}
